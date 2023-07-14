namespace AIR_MASTER_CONTROL;

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

    private void WebBrowser1DocumentCompleted(object sender,
           WebBrowserDocumentCompletedEventArgs e)
    {
        this.webBrowser1.Size = new Size(this.Size.Width, this.Size.Height);
    }
    private void Form1_ResizeEnd(object sender, System.EventArgs e)
    {
        Control control = (Control)sender;
        this.webBrowser1.Size = new Size(this.Size.Width, this.Size.Height);
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
    }
}
