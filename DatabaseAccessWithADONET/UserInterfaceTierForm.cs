/*--------------------------------------------------------------------------------
* Author	 :	Hüseyin Altindag
* Created :	16/08/2004
* Changes : 29/10/2004 
*				included a new method "private void fnSelectUnselectCurrentRow(num1,num2)"
*				which select or unselect the current row or previous row on the DataGrid. 
*				If user clicks	the navigation buttons(Next,Previous) 
*				the clicked row will be selected and highlighted(SelectionBackColor=blue, SelecttionForeColor=Yellow)
*				and the previous row will be shown as default.
*
*				3/11/2004
*				included the ProcessCmdKey method which I copied from MSDN Library
*				and made some little changes to trap specific keys(up, down..) in a Datagrid
*
* Purpose :	This is a simple ADO.NET database application that returns results 
				from a data source, writes the output to a DataGrid and TextBoxes, 
				and uses Buttons to navigate through records.
*				It also includes : 
*				1. What is ADO.NET
*				2. Connection to a database
*				3. Use of a DataSet to fill with records 				
*				4. Use of a DataAdapter to load data into the DataSet  
*				5. Display data in a DataGrid
*				6. DataBindings for TextBoxes
*				7. Use of the CurrencyManager
*				8. Navigation through records with Next,Previous,Last,First buttons.
*				9. How to trap keystrokes in the DataGrid(Up,Down, Esc, ...)
---------------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;


namespace DatabaseAccessWithADONET
{
  /// <summary>
  /// Summary description for CurrencyManagerForm.
  /// </summary>
  public class DatabaseAccessWithADONETForm : System.Windows.Forms.Form
  {
	 
	 private System.Windows.Forms.TextBox textboxCity;
	 private System.Windows.Forms.DataGrid dataGrid1;
	 public CurrencyManager currManager; 
	 private System.Windows.Forms.Button btFirst;
	 private System.Windows.Forms.Button btNext;
	 private System.Windows.Forms.Button btPrevious;
	 private System.Windows.Forms.Button btLast;
	 private System.Windows.Forms.Button btExit;
	 private System.Windows.Forms.StatusBar statusBar1;
	 private System.Windows.Forms.Label label1;
	 private System.Windows.Forms.Label label2;
	 private System.Windows.Forms.Label label3;
	 private DataSet ds=new DataSet();
	 //create an instance "datc" of the class DataAccessTierClass
	 DataAccessTierClass datc=new DataAccessTierClass();
    private System.Windows.Forms.TextBox textboxFirstname;
    private System.Windows.Forms.TextBox textboxLastname;
    private System.Windows.Forms.MainMenu mainMenu1;
    private System.Windows.Forms.MenuItem miAbout;
    private System.Windows.Forms.MenuItem miFile;
    private System.Windows.Forms.MenuItem menuItem1;
    private System.Windows.Forms.MenuItem miExit;
    public FormAbout frm1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox textboxTitle;
    private System.Windows.Forms.TextBox textboxCountry;
	 private static int nPos=0; //get the current position of the record
	 private int iRowIndex;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.StatusBarPanel statusBarPanel1;
    private System.Windows.Forms.StatusBarPanel statusBarPanel2;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.ComponentModel.IContainer components;

	 public DatabaseAccessWithADONETForm()
	 {
		//
		// Required for Windows Form Designer support
		//
		InitializeComponent();		
		//
		// TODO: Add any constructor code after InitializeComponent call
		//
	 }

	 /// <summary>
	 /// Clean up any resources being used.
	 /// </summary>
	 protected override void Dispose( bool disposing )
	 {
		if( disposing )
		{
		  if(components != null)
		  {
			 components.Dispose();
		  }
		}
		base.Dispose( disposing );
	 }

	 #region Windows Form Designer generated code
	 /// <summary>
	 /// Required method for Designer support - do not modify
	 /// the contents of this method with the code editor.
	 /// </summary>
	 private void InitializeComponent()
	 {
		this.components = new System.ComponentModel.Container();
		this.textboxLastname = new System.Windows.Forms.TextBox();
		this.textboxCity = new System.Windows.Forms.TextBox();
		this.btFirst = new System.Windows.Forms.Button();
		this.btNext = new System.Windows.Forms.Button();
		this.btPrevious = new System.Windows.Forms.Button();
		this.btLast = new System.Windows.Forms.Button();
		this.dataGrid1 = new System.Windows.Forms.DataGrid();
		this.btExit = new System.Windows.Forms.Button();
		this.statusBar1 = new System.Windows.Forms.StatusBar();
		this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
		this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.textboxFirstname = new System.Windows.Forms.TextBox();
		this.mainMenu1 = new System.Windows.Forms.MainMenu();
		this.miFile = new System.Windows.Forms.MenuItem();
		this.miAbout = new System.Windows.Forms.MenuItem();
		this.menuItem1 = new System.Windows.Forms.MenuItem();
		this.miExit = new System.Windows.Forms.MenuItem();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.textboxCountry = new System.Windows.Forms.TextBox();
		this.textboxTitle = new System.Windows.Forms.TextBox();
		this.label5 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.label6 = new System.Windows.Forms.Label();
		this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
		((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
		((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
		((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
		this.groupBox1.SuspendLayout();
		this.SuspendLayout();
		// 
		// textboxLastname
		// 
		this.textboxLastname.BackColor = System.Drawing.Color.White;
		this.textboxLastname.Location = new System.Drawing.Point(80, 64);
		this.textboxLastname.Name = "textboxLastname";
		this.textboxLastname.ReadOnly = true;
		this.textboxLastname.Size = new System.Drawing.Size(144, 20);
		this.textboxLastname.TabIndex = 4;
		this.textboxLastname.Text = "";
		// 
		// textboxCity
		// 
		this.textboxCity.BackColor = System.Drawing.Color.White;
		this.textboxCity.Location = new System.Drawing.Point(80, 128);
		this.textboxCity.Name = "textboxCity";
		this.textboxCity.ReadOnly = true;
		this.textboxCity.Size = new System.Drawing.Size(144, 20);
		this.textboxCity.TabIndex = 5;
		this.textboxCity.Text = "";
		// 
		// btFirst
		// 
		this.btFirst.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.btFirst.Location = new System.Drawing.Point(128, 280);
		this.btFirst.Name = "btFirst";
		this.btFirst.TabIndex = 7;
		this.btFirst.Text = "First |<";
		this.btFirst.Click += new System.EventHandler(this.btFirst_Click);
		// 
		// btNext
		// 
		this.btNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.btNext.Location = new System.Drawing.Point(320, 280);
		this.btNext.Name = "btNext";
		this.btNext.TabIndex = 8;
		this.btNext.Text = "Next >";
		this.btNext.Click += new System.EventHandler(this.btNext_Click);
		// 
		// btPrevious
		// 
		this.btPrevious.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.btPrevious.Location = new System.Drawing.Point(224, 280);
		this.btPrevious.Name = "btPrevious";
		this.btPrevious.TabIndex = 9;
		this.btPrevious.Text = "Previous <";
		this.btPrevious.Click += new System.EventHandler(this.btPrevious_Click);
		// 
		// btLast
		// 
		this.btLast.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.btLast.Location = new System.Drawing.Point(416, 280);
		this.btLast.Name = "btLast";
		this.btLast.TabIndex = 10;
		this.btLast.Text = "Last >|";
		this.btLast.Click += new System.EventHandler(this.btLast_Click);
		// 
		// dataGrid1
		// 
		this.dataGrid1.CaptionText = "Person DataGrid";
		this.dataGrid1.DataMember = "";
		this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dataGrid1.Location = new System.Drawing.Point(256, 56);
		this.dataGrid1.Name = "dataGrid1";
		this.dataGrid1.Size = new System.Drawing.Size(488, 200);
		this.dataGrid1.TabIndex = 6;
		this.toolTip1.SetToolTip(this.dataGrid1, "if you click the last column cells you get an error");
		this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
		this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
		// 
		// btExit
		// 
		this.btExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.btExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.btExit.ForeColor = System.Drawing.SystemColors.WindowText;
		this.btExit.Location = new System.Drawing.Point(512, 280);
		this.btExit.Name = "btExit";
		this.btExit.TabIndex = 11;
		this.btExit.Text = "Exit";
		this.btExit.Click += new System.EventHandler(this.btExit_Click);
		// 
		// statusBar1
		// 
		this.statusBar1.Dock = System.Windows.Forms.DockStyle.None;
		this.statusBar1.Location = new System.Drawing.Point(0, 327);
		this.statusBar1.Name = "statusBar1";
		this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																											 this.statusBarPanel1,
																											 this.statusBarPanel2});
		this.statusBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.statusBar1.ShowPanels = true;
		this.statusBar1.Size = new System.Drawing.Size(758, 22);
		this.statusBar1.TabIndex = 12;
		// 
		// statusBarPanel1
		// 
		this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
		this.statusBarPanel1.Text = "Panel1";
		this.statusBarPanel1.Width = 732;
		// 
		// statusBarPanel2
		// 
		this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
		this.statusBarPanel2.Width = 10;
		// 
		// label1
		// 
		this.label1.Location = new System.Drawing.Point(16, 32);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(56, 16);
		this.label1.TabIndex = 0;
		this.label1.Text = "FirstName";
		this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// label2
		// 
		this.label2.Location = new System.Drawing.Point(16, 64);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(56, 16);
		this.label2.TabIndex = 1;
		this.label2.Text = "LastName";
		this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// label3
		// 
		this.label3.Location = new System.Drawing.Point(16, 128);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(56, 16);
		this.label3.TabIndex = 2;
		this.label3.Text = "City";
		this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// textboxFirstname
		// 
		this.textboxFirstname.BackColor = System.Drawing.Color.White;
		this.textboxFirstname.Location = new System.Drawing.Point(80, 32);
		this.textboxFirstname.Name = "textboxFirstname";
		this.textboxFirstname.ReadOnly = true;
		this.textboxFirstname.Size = new System.Drawing.Size(144, 20);
		this.textboxFirstname.TabIndex = 3;
		this.textboxFirstname.Text = "";
		// 
		// mainMenu1
		// 
		this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																										this.miFile});
		// 
		// miFile
		// 
		this.miFile.Index = 0;
		this.miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																									this.miAbout,
																									this.menuItem1,
																									this.miExit});
		this.miFile.Text = "&File";
		// 
		// miAbout
		// 
		this.miAbout.Index = 0;
		this.miAbout.Text = "About...";
		this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
		// 
		// menuItem1
		// 
		this.menuItem1.Index = 1;
		this.menuItem1.Text = "-";
		// 
		// miExit
		// 
		this.miExit.Index = 2;
		this.miExit.Text = "Exit";
		this.miExit.Click += new System.EventHandler(this.miExit_Click);
		// 
		// groupBox1
		// 
		this.groupBox1.BackColor = System.Drawing.Color.OliveDrab;
		this.groupBox1.Controls.Add(this.textboxCountry);
		this.groupBox1.Controls.Add(this.textboxTitle);
		this.groupBox1.Controls.Add(this.label5);
		this.groupBox1.Controls.Add(this.label4);
		this.groupBox1.Controls.Add(this.textboxFirstname);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Controls.Add(this.textboxLastname);
		this.groupBox1.Controls.Add(this.textboxCity);
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Controls.Add(this.label3);
		this.groupBox1.Location = new System.Drawing.Point(8, 56);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(240, 200);
		this.groupBox1.TabIndex = 13;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Person Details";
		// 
		// textboxCountry
		// 
		this.textboxCountry.Location = new System.Drawing.Point(80, 160);
		this.textboxCountry.Name = "textboxCountry";
		this.textboxCountry.ReadOnly = true;
		this.textboxCountry.Size = new System.Drawing.Size(144, 20);
		this.textboxCountry.TabIndex = 9;
		this.textboxCountry.Text = "";
		// 
		// textboxTitle
		// 
		this.textboxTitle.Location = new System.Drawing.Point(80, 96);
		this.textboxTitle.Name = "textboxTitle";
		this.textboxTitle.ReadOnly = true;
		this.textboxTitle.Size = new System.Drawing.Size(144, 20);
		this.textboxTitle.TabIndex = 8;
		this.textboxTitle.Text = "";
		// 
		// label5
		// 
		this.label5.Location = new System.Drawing.Point(16, 160);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(56, 16);
		this.label5.TabIndex = 7;
		this.label5.Text = "Country";
		// 
		// label4
		// 
		this.label4.Location = new System.Drawing.Point(16, 96);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(56, 16);
		this.label4.TabIndex = 6;
		this.label4.Text = "Title";
		// 
		// textBox1
		// 
		this.textBox1.Location = new System.Drawing.Point(512, 24);
		this.textBox1.Name = "textBox1";
		this.textBox1.ReadOnly = true;
		this.textBox1.Size = new System.Drawing.Size(144, 20);
		this.textBox1.TabIndex = 14;
		this.textBox1.Text = "";
		// 
		// label6
		// 
		this.label6.Location = new System.Drawing.Point(376, 24);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(136, 16);
		this.label6.TabIndex = 15;
		this.label6.Text = "Current Cell/Row Content:";
		this.label6.TextAlign = System.Drawing.ContentAlignment.BottomRight;
		// 
		// DatabaseAccessWithADONETForm
		// 
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.BackColor = System.Drawing.Color.Olive;
		this.ClientSize = new System.Drawing.Size(758, 349);
		this.Controls.Add(this.label6);
		this.Controls.Add(this.textBox1);
		this.Controls.Add(this.groupBox1);
		this.Controls.Add(this.statusBar1);
		this.Controls.Add(this.btExit);
		this.Controls.Add(this.dataGrid1);
		this.Controls.Add(this.btLast);
		this.Controls.Add(this.btPrevious);
		this.Controls.Add(this.btNext);
		this.Controls.Add(this.btFirst);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		this.MaximizeBox = false;
		this.Menu = this.mainMenu1;
		this.Name = "DatabaseAccessWithADONETForm";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Using ADO.NET Database 1";
		this.Load += new System.EventHandler(this.CurrencyManagerForm_Load);
		((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
		((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
		((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
		this.groupBox1.ResumeLayout(false);
		this.ResumeLayout(false);

	 }
	 #endregion
		
		
	 [STAThread]
	 static void Main() 
	 {
		Application.EnableVisualStyles();
		Application.Run(new DatabaseAccessWithADONETForm());
	 }

	 #region  AllMethods to navigate with buttons	
	 /*---------------------------------------------------------
	  *  All functions(fn)/methods to navigate with buttons
	  *--------------------------------------------------------*/
		
	 private void btFirst_Click(object sender, System.EventArgs e)
	 {
		if((currManager!=null)&(currManager.Count>0)) 
		{
		  fnClearStatusbarPanel2();
		  fnSelectUnselectLastFirstRow(0);
		  //set the position at the first record 0
		  currManager.Position=0;
		  //enable pushbuttons Next, Last
		  fnEnableDisableButtons(this.btNext,this.btLast,"", true);
		  //disable pushbuttons First, Previous
		  fnEnableDisableButtons(this.btFirst, this.btPrevious,"First record...",false);           	
		  //display record numbers in the StatusBar
		  fnDisplayRecordNumbers(); 
		}
	 }

	 private void fnSelectUnselectLastFirstRow (int posi)
	 {
		//unselect the last selected/highlighted row	
		this.dataGrid1.UnSelect(this.dataGrid1.CurrentRowIndex);
		//select the last or first row
		this.dataGrid1.Select(posi);
	 }
	 

	 private void btNext_Click(object sender, System.EventArgs e)
	 {		
		//check if position in the table less than the number of  records 
		if((currManager!=null) &(currManager.Count>0)&(currManager.Position<currManager.Count-1)) 
		{			
		  fnClearStatusbarPanel2();  
		  fnSelectUnselectCurrentRow(1,-1);
		  //increase the position in the table		
		  currManager.Position +=1;
		  //enable pushbuttons First, Previous
		  fnEnableDisableButtons(this.btFirst, this.btPrevious,"",true);	
		  //display record numbers in the StatusBar
		  fnDisplayRecordNumbers(); 				
		} else { //there is no records in the table
			 //disable pushbuttons Next, Last
			 fnEnableDisableButtons(this.btNext, this.btLast,"End of records...",false);  
		  //display record numbers in the StatusBar
			 fnDisplayRecordNumbers(); 
		  }//else		  
	 }
		
	private void fnSelectUnselectCurrentRow(int num1, int num2)
	{
		//get the current row index
		this.iRowIndex=this.dataGrid1.CurrentRowIndex;
		//increase or decrease the index by (num1,bum2)1,-1 or -1,1 depending on 
		//Next or Previous button because we want to select next or previous row
		//if num1 is 1 you clicked Next so select next row
		//if num1 -1 you clicked Previous so select previous row
		//I use in both select and unselect plus(+)
		// it´s like in math: e.g. 7+(-1)=7-1=6 or 7+(1)=7+1=8
		this.iRowIndex=this.iRowIndex+num1;
		//select the current row	
		this.dataGrid1.Select(this.iRowIndex);  
		//decrease or increase the index by -1 or 1 so that we can unselect the previous  row	
		this.iRowIndex=this.iRowIndex+num2;
		//unselect the previous row	
		this.dataGrid1.UnSelect(this.iRowIndex);
	}	
		
	 private void btPrevious_Click(object sender, System.EventArgs e)
	 {
		//check if position in the table greater than the number of  records 
		if((currManager!=null)&(currManager.Count>0)&(currManager.Position>0)) 
		{
		  fnClearStatusbarPanel2();
		  fnSelectUnselectCurrentRow(-1,1);
		  //set the position back			
		  currManager.Position -=1; 
		  //enable pushbuttons Last,Next
		  fnEnableDisableButtons(this.btNext, this.btLast,"",true);  
		  //display record numbers in the StatusBar
		  fnDisplayRecordNumbers(); 			
		}
		else 
		{
		  //there is no previous record any more
		  //disable pushbuttons First,Previous with function(fn) fnEnableDisableButtons
		  fnEnableDisableButtons(this.btFirst, this.btPrevious,"Beginning of records...",false);        
		  //display record numbers in the StatusBar
		  fnDisplayRecordNumbers(); 
		}//else		
	 }
		
	 private void btLast_Click(object sender, System.EventArgs e)
	 {
		fnClearStatusbarPanel2();
		fnSelectUnselectLastFirstRow(this.currManager.Count-1);
		//set the position at the last record
		//because record position starts with 0 ; that´s why -1
		this.currManager.Position=this.currManager.Count-1;	
		//disable pushbuttons Next, Last
		fnEnableDisableButtons(this.btNext, this.btLast,"",false);        
		//enable pushbuttons First, Previous
		fnEnableDisableButtons(this.btFirst, this.btPrevious,"Last Record...", true);
		//display record numbers in the StatusBar
		fnDisplayRecordNumbers(); 
	 }
	 
	 private void fnClearStatusbarPanel2()
	 {
		this.statusBarPanel2.Text="";
	 }
	 
	  /*-----------------------------------------------------------------------*/
  
	 private void btExit_Click(object sender, System.EventArgs e)
	 {
		//ask user before quit
		//1.way
		/*
		DialogResult dr=MessageBox.Show("Are you sure you want to quit ?","Confirm", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
		if (dr==DialogResult.Yes)
		  Application.Exit();
		*/
		//2.way 
		ExitClass ec=new ExitClass(); 
		ec.fnExitUniversal(); //invoke the method "fnExitUniversal" from the class "ExitClass"		  
		  
		  
	 }
		
	 private void fnEnableDisableButtons(Button bt1, Button bt2, string str, bool b) 
	 {
		bt1.Enabled=b;
		bt2.Enabled=b;
		this.statusBarPanel1.Text=str;   
	 }
	
	 private void CurrencyManagerForm_Load(object sender, System.EventArgs e)
	 {
		//check the connection to database
		if (this.datc.fnGetDataConnection()) {
		  //connection was ok.
		  this.dataGrid1.AlternatingBackColor=Color.Wheat;	
		  this.dataGrid1.ReadOnly=true;
		  this.dataGrid1.DataSource=datc.dSet.Tables["PersonTable"];
		  //invoke the method for DataBinding of TextBoxes
		  fnGetDataBindingForTextBoxes();
		  //set CurrencyManager for the "PersonTable" table
		  fnSetCurrencyManager();		
		  //display record numbers in the StatusBar
		  fnDisplayRecordNumbers(); 
		} else { 				
					 MessageBox.Show("Connection failed...");
					 Application.Exit(); //end the program
				 }		
					   														
	 }

	 private void fnGetDataBindingForTextBoxes()
	 {
		//DataBindings for all TextBoxes on the Form
		this.textboxFirstname.DataBindings.Add("Text", datc.dSet.Tables["PersonTable"],"FirstName");
		this.textboxLastname.DataBindings.Add("Text", datc.dSet.Tables["PersonTable"],"LastName");
		this.textboxTitle.DataBindings.Add("Text", datc.dSet.Tables["PersonTable"],"Title");
		this.textboxCity.DataBindings.Add("Text", datc.dSet.Tables["PersonTable"],"City");
		this.textboxCountry.DataBindings.Add("Text", datc.dSet.Tables["PersonTable"],"Country");
	 }
	  	
	 public void fnSetCurrencyManager()
	 {
		//Initialize CurrencyManager for the table "PersonTable" 
		currManager=(CurrencyManager)this.BindingContext[datc.dSet.Tables["PersonTable"]];										
	 }	

	 private void fnDisplayRecordNumbers()
	 {
		//get the current position of the record and display it in StatusBar
		nPos=this.currManager.Position+1;
		this.statusBarPanel1.Text +=" Record:   "+nPos.ToString()+" of  "+this.currManager.Count.ToString();                    
	 }

    private void miExit_Click(object sender, System.EventArgs e)
	 {
		ExitClass ec=new ExitClass(); 
		ec.fnExitUniversal(); //invoke the method "fnExitUniversal" from the class "ExitClass"		  
	 }

    private void miAbout_Click(object sender, System.EventArgs e)
	 {
		frm1=new FormAbout();
		frm1.ShowDialog();
		 
	 }

	 private void  fnDisplayRecordNumbers2()
	 {
		nPos=this.currManager.Position;
		//you are on the first record
		if (nPos==0) 
		{
		  fnEnableDisableButtons(this.btNext,this.btLast,"", true);
		  //disable pushbuttons First, Previous
		  fnEnableDisableButtons(this.btFirst, this.btPrevious,"First record...",false);           	
		  //display record numbers in the StatusBar
		  fnDisplayRecordNumbers(); 
		} 
		else
		  if (nPos==this.currManager.Count-1) 
		  // you are on the last record
		  {
			 //disable pushbuttons Next, Last
			 fnEnableDisableButtons(this.btNext, this.btLast,"",false);        
			 //enable pushbuttons First, Previous
			 fnEnableDisableButtons(this.btFirst, this.btPrevious,"Last Record...", true);
			 //display record numbers in the StatusBar
			 fnDisplayRecordNumbers(); 
		 } 
		 else 
		 {
			 //enable pushbuttons First, Previous
			 fnEnableDisableButtons(this.btFirst, this.btPrevious,"", true);
			 //enable pushbuttons Next, Last
			 fnEnableDisableButtons(this.btNext, this.btLast,"",true);   
			 fnDisplayRecordNumbers();      
		 }
		++nPos;
	 }
	 
	 
	 
	 /*--------------------------------------------------------------------------
		You want to navigate and click with mouse the rows in the DataGrid
	 ----------------------------------------------------------------------------*/
    private void dataGrid1_Click(object sender, System.EventArgs e)
	 {		
		fnClearStatusbarPanel2();
		fnDisplayRecordNumbers2();
	 }
    
    #endregion

    
	 //you click in the cell of the Datagrid and get the content of it
    private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
	 {
		/*be warned: if you click the last cell on the Datagrid you get 
		an unhandled exception of type 'System.ArgumentOutOfRangeException.
		because there is no further columns after the last column(Country)
		to avoid this I tried a different way: in a try-catch get the right 
		cell content. if the last column cell clicked display the exception
		and the cell content one before
		*/
		//get the row number on the DataGrid 
		int iRownr=this.dataGrid1.CurrentCell.RowNumber;
		//get the column number on the DataGrid 
		int iColnr=this.dataGrid1.CurrentCell.ColumnNumber;
		//get the content of the cell in the clicked cell on the Datagrid
		object cellvalue1=this.dataGrid1[iRownr, iColnr];
		//get the next cell content in the same row 
		object cellvalue2=null;
		try {
		  cellvalue2=this.dataGrid1[iRownr, iColnr+1];
		  //display (cellvalue1+cellvalue2) in TextBox "textBox1" 
		  this.textBox1.Text=cellvalue1.ToString()+" "+cellvalue2.ToString();
		}
		catch(Exception ex) 
		{
		  //the exception occurs here because we increment iColnr+1
		  //delete or comment MessageBox.Show-line you won´t get the error message 
		  MessageBox.Show("No further columns after the last column(Country) -->> "+ex.Message,"STOP");
		  cellvalue2=this.dataGrid1[iRownr, iColnr-1]; 
		  //display this time (cellvalue2+cellvalue1) in TextBox "textBox1" 
		  this.textBox1.Text=cellvalue2.ToString()+" "+cellvalue1.ToString(); 
		}//catch
	 }

	 protected override bool ProcessCmdKey(ref Message msg, Keys keyData)	
	 {
		const int WM_KEYDOWN = 0x100;
		const int WM_SYSKEYDOWN = 0x104;

		if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
		{
		  switch(keyData)
		  {
			 case Keys.Down:
				this.statusBarPanel2.Text="Down";
				this.statusBarPanel1.Text = "Trapped keystrokes ...";
				break;
      
			 case Keys.Up:
				this.statusBarPanel2.Text="Up";
				this.statusBarPanel1.Text = "Trapped keystrokes ...";
				break;
				
			case Keys.NumLock:
			  this.statusBarPanel2.Text="NumLock";
			  this.statusBarPanel1.Text = "Trapped keystrokes ...";
			  break;
			
			case Keys.Escape:
			  this.statusBarPanel2.Text="Escape";
			  this.statusBarPanel1.Text = "Trapped keystrokes ...";
			  ExitClass ec=new ExitClass(); 
			  ec.fnExitUniversal();	 //invoke the method "fnExitUniversal" from the class "ExitClass"
			  break;
			  
			 /*
			 case Keys.Tab:
				this.statusBarPanel1.Text="Tab Key Captured";
				break;
 
			 case Keys.Control | Keys.M:
				this.statusBarPanel1.Text="<CTRL> + M Captured";
				break;
 
			 case Keys.Alt | Keys.Z:
				this.statusBarPanel1.Text="<ALT> + Z Captured";
				break;
			*/
		  }				
		}

		return base.ProcessCmdKey(ref msg,keyData);
	 }
    
  } //class
}//namespace
	 
