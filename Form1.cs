namespace AIR_MASTER_CONTROL;
using System.IO.Ports;

public partial class Form1 : Form
{
     public string MessageInTextarea1 = " ";
    SerialPort MyPort;
    public Form1()
    {
        InitializeComponent();
    }
     private void MyPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
 	        System.Threading.Thread.Sleep(100);
 	        
 	        if(MyPort.IsOpen){
            int bytes = MyPort.BytesToRead;
            byte[]  read_buf = new byte[bytes];
            MyPort.Read(read_buf, 0, bytes);
               
            //string POT = MyPort.Read();
            this.BeginInvoke(new LineReceivedEvent(LineReceived), read_buf);
 	        }
        }

 public void ConnectToCom (string COM_Name, int ConnectOrDisconnect){
	if(ConnectOrDisconnect == 1){
			MyPort= new SerialPort(COM_Name , 115200, Parity.None, 8, StopBits.One);
			MyPort.ReadTimeout = 100;
            MyPort.WriteTimeout = 100;
            MyPort.ReadBufferSize = 4096;
            MyPort.WriteBufferSize = 4096;
            MyPort.DataReceived += new SerialDataReceivedEventHandler(MyPort_DataReceived);
            MyPort.Encoding = System.Text.Encoding.GetEncoding("windows-1251");
            MyPort.Open();
			byte[] data = { 0, 1, 2, 1, 0 };
            MyPort.Write(data, 0, data.Length);		
			}
	else{
		  //  System.Threading.Thread.Sleep(300);
			MyPort.Close();
			}
		
		}
		
  public void SaveToCSV (string FieldStr, int ExtraParam){
    SaveFileDialog saveFileDialog1 = new SaveFileDialog();      
    saveFileDialog1.InitialDirectory = "C:\\"; 
    saveFileDialog1.FileName = "Leakage"+DateTime.Now.ToString().Replace('/','_').Replace(':','_')+".csv";
    saveFileDialog1.Title = "Save CSV File";      
    saveFileDialog1.CheckFileExists = false;      
    saveFileDialog1.CheckPathExists = true;      
    saveFileDialog1.DefaultExt = "csv";      
    saveFileDialog1.Filter = "CSV files (*.csv)|*.csv";      
    saveFileDialog1.FilterIndex = 1;      
    saveFileDialog1.RestoreDirectory = true;      
    if (saveFileDialog1.ShowDialog() == DialogResult.OK) {      
        using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
        sw.WriteLine (FieldStr);     
    }      
		
		}


}
