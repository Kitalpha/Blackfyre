<%@ Page
    Language="C#"
    AutoEventWireup="false"
    Inherits="Tesseract.WebDemo.DefaultPage"
    ValidateRequest="false"
    EnableSessionState="false" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <title>Tesseract Web Demo</title>

    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />
    <meta http-equiv="PRAGMA" content="NO-CACHE" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- Bootstrap -->
    <link href="Content/bootstrap.min.css" rel="stylesheet">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
	      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
	      <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
   	 	<![endif]-->

    <script>

    // Detect if the browser is IE or not.
    // If it is not IE, we assume that the browser is NS.
    //var IE = document.all?true:false

    //// If NS -- that is, !IE -- then set up for mouse capture
    //if (!IE) document.captureEvents(Event.MOUSEMOVE)

    //// Set-up to use getMouseXY function onMouseMove
    //document.onmousemove = getMouseXY;

    //// Temporary variables to hold mouse x-y pos.s
    //var tempX = 0
    //var tempY = 0

    // Main function to retrieve mouse x-y pos.s

    //function getMouseXY(e) {
    //  if (IE) { // grab the x-y pos.s if browser is IE
    //    tempX = event.clientX + document.body.scrollLeft
    //    tempY = event.clientY + document.body.scrollTop
    //  } else {  // grab the x-y pos.s if browser is NS
    //    tempX = e.pageX
    //    tempY = e.pageY
    //  }  
    //  // catch possible negative values in NS4
    //  if (tempX < 0){tempX = 0}
    //  if (tempY < 0){tempY = 0}  

    //  console.log(tempX);
    //  console.log(tempY);
    //  return true
    //}

    //onmousemove = function (e) { console.log("mouse location:", e.screenX, e.screenY) }

    
    </script>

</html>
<body>
    <div class="container">
        <form id="Form1" method="post" role="form" runat="server">
            <asp:Panel ID="inputPanel" runat="server">
                <fieldset>
                    <legend>File Upload</legend>
                    <div class="form-group">
                        <label for="imageFile" runat="server">File:</label>
                        <input class="form-control" type="file" id="imageFile" runat="server" />
                        <span class="help-block">The file to be processed.</span>
                    </div>
                    <button id="submitFile" type="submit" class="btn btn-default" runat="server">Submit</button>
                    <button id="grabArea" type="submit" class="btn btn-default" runat="server">Grab Area</button>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="resultPanel" Visible="False" runat="server">
                <fieldset>
                    <legend>OCR Results</legend>
                    <div class="form-group">
                        <label for="result" runat="server">Mean Confidence:</label>
                        <label class="form-control" id="meanConfidenceLabel" runat="server" />
                    </div>
                    <div class="form-group">
                        <label for="result" runat="server">Result:</label>
                        <textarea class="form-control" rows="10" id="resultText" readonly="readonly" runat="server"></textarea>
                    </div>
                    <button id="restartButton" type="submit" class="btn btn-default" runat="server">Restart</button>
                </fieldset>
            </asp:Panel>
        </form>
    </div>
</body>
</html>
