/*------------------------------------------------------------------------------
 *	Created : 03.01.2004 by Hüseyin Altindag
 *	Usage	  : in order to use it, include it in your project, 
 *			    instantiate it there where you need it and invoke it
 * example : You click Exit button on your Form and instantiate it in event handler
 *			    ExitClass ec=new ExitClass();	and invoke
 *			    ec.fnExitUniversal();
 ------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;

	/// <summary>
	/// Summary description for ExitClass.
	/// </summary>
	public class ExitClass
	{	
		/*-------------------------------------------------------------------------
		* public method 
		* Overloaded	: no
		* Parameters	: no
		* Return value	: no
		* Purpose		: displays a message asking the user to finish the program
		*-------------------------------------------------------------------------*/
		public void fnExitUniversal() 
		{
		  DialogResult dr=MessageBox.Show("Are you sure to end the program ?", "Finish ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);	
		  if (dr ==DialogResult.Yes) 
		  {	
			 Application.Exit();
		  }//if
		}		
	}//class 
