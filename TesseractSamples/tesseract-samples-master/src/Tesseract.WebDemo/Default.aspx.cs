/*
 * Created by SharpDevelop.
 * User: W110
 * Date: 15/12/2013
 * Time: 8:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace Tesseract.WebDemo
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public class DefaultPage : System.Web.UI.Page
	{	
		#region Data

        // input panel controls

        protected Panel inputPanel;
		protected HtmlInputFile imageFile;
		protected HtmlButton submitFile;
        protected HtmlButton grabArea;

        // result panel controls
        protected Panel resultPanel;
        protected HtmlGenericControl meanConfidenceLabel;
        protected HtmlTextArea resultText;
        protected HtmlButton restartButton;


		#endregion

		#region Event Handlers

		private void OnSubmitFileClicked(object sender, EventArgs args)
		{
            if (imageFile.PostedFile != null && imageFile.PostedFile.ContentLength > 0)
            {
            	// for now just fail hard if there's any error however in a propper app I would expect a full demo.
            	
                using (var engine = new TesseractEngine(Server.MapPath(@"~/tessdata"), "eng", EngineMode.Default))
                {
                    // have to load Pix via a bitmap since Pix doesn't support loading a stream.
                    using (var image = new System.Drawing.Bitmap(imageFile.PostedFile.InputStream))
                    {
                        using (var pix = PixConverter.ToPix(image))
                        {
                            using (var page = engine.Process(pix))
                            {
                                meanConfidenceLabel.InnerText = String.Format("{0:P}", page.GetMeanConfidence());
                                resultText.InnerText = page.GetText();
                            }
                        }
                    }
                }
                inputPanel.Visible = false;
                resultPanel.Visible = true;
            }
		}

        private void OnRestartClicked(object sender, EventArgs args)
        {
            resultPanel.Visible = false;
            inputPanel.Visible = true;
        }

		#endregion

		#region Page Setup
		protected override void OnInit(EventArgs e)
		{
			InitializeComponent();
            CaptureApplication("devenv");
            base.OnInit(e);
		}

		//----------------------------------------------------------------------
		private void InitializeComponent()
		{
            this.restartButton.ServerClick += OnRestartClicked;
			this.submitFile.ServerClick += OnSubmitFileClicked;
            this.grabArea.ServerClick += OnGrabAreaClicked;
		}

        private void OnGrabAreaClicked(object sender, EventArgs e)
        {

        }

        public void CaptureApplication(string procName)
        {
            var proc = Process.GetProcessesByName(procName)[0];
            var rect = new User32.Rect();
            User32.GetWindowRect(proc.MainWindowHandle, ref rect);

            int width = rect.right - rect.left;
            int height = rect.bottom - rect.top;

            var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.CopyFromScreen(rect.left, rect.top, 0, 0, new Size(300, 300), CopyPixelOperation.SourceCopy);

            bmp.Save("C:\\Users\\christopher\\Documents\\visual studio 2015\\Projects\\CheaterOfSalem\\TesseractSamples\\tesseract-samples-master\\src\\Tesseract.WebDemo\\temp\\temp.png", System.Drawing.Imaging.ImageFormat.Png);
        }
        #endregion
    }
}