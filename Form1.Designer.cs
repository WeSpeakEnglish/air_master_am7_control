namespace AIR_MASTER_CONTROL;
using System.IO.Ports;


partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.WebBrowser webBrowser1;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }
    private int ListComPorts(System.Windows.Forms.HtmlDocument document){
         string[] ports = SerialPort.GetPortNames();
         Object[] objArray = new Object[ports.Length];

         for (int i = 0; i < objArray.Length; i++)
                objArray[i] = (Object)(ports[i]);

        document.InvokeScript("ListComPorts", objArray);
        return 0;
    }
    		// ComList("WritePorts","Connected!");
		 public void ComList(String COMfunction,String message)
    {
         System.Windows.Forms.HtmlDocument document = this.webBrowser1.Document;
 		 Object[] objArray = new Object[1];
 		 objArray[0] = (Object)(message);
 		 document.InvokeScript(COMfunction,objArray);
		 }
 
      private delegate void LineReceivedEvent(byte[] read_buf);
 
        private void LineReceived(byte[] read_buf)
        {

//      DataConverters DataConverter1 = new DataConverters();
      Int32[] ValuesOfSource =  new Int32[10];



      if(read_buf.Length != 32)
      	return;
     
      if(read_buf[0] == 0x40){

//     	DataConverter1.SetValuesToHTML(this.webBrowser1.Document, ref ValuesOfSource);
    
   
        string dataStringHEX = BitConverter.ToString(read_buf);
 
        dataStringHEX = dataStringHEX.Replace("-"," ");
        ComList("WritePorts",dataStringHEX);
        }    
 
        }


    private void WebBrowser1DocumentCompleted(object sender,
           WebBrowserDocumentCompletedEventArgs e)
    {
        this.webBrowser1.Size = new Size(this.Size.Width - 15, this.Size.Height - 15);
        
        string[] ports = SerialPort.GetPortNames();
		 string MessageInnerHTML=null;
		 Array.Sort(ports);
        foreach(string port in ports){
        	MessageInnerHTML+="<option value="+port.ToString()+">"+port.ToString()+"</option>";
        }
        ComList("CreateCOMportsList",MessageInnerHTML);
    }
    private void Form1_ResizeEnd(object sender, System.EventArgs e)
    {
        Control control = (Control)sender;
        this.webBrowser1.Size = new Size(this.Size.Width - 15, this.Size.Width - 15);
    }
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.webBrowser1 = new System.Windows.Forms.WebBrowser();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "Form1";
        this.webBrowser1.Name = "webBrowser1";
        this.webBrowser1.ScrollBarsEnabled = false;
        this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowser1DocumentCompleted);
        this.webBrowser1.AllowWebBrowserDrop = false;
        this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
        this.webBrowser1.WebBrowserShortcutsEnabled = false;
        this.webBrowser1.ObjectForScripting = this;
        this.ResizeEnd += new EventHandler(Form1_ResizeEnd);
        string curDir = Directory.GetCurrentDirectory();
        this.webBrowser1.Url = new System.Uri(String.Format("file:///{0}/interface/title.html", curDir));
        this.Controls.Add(this.webBrowser1);
        this.ResumeLayout(false);
        this.PerformLayout();
        this.ListComPorts(this.webBrowser1.Document);
    }
}
