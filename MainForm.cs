/*
 * Created by SharpDevelop.
 * User: Riisa
 * Date: 02.01.2020
 * Time: 12:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SpeechCode
{

	/****************************************/
	/*              FACTORY                 */
	/****************************************/
///////////////////////////////////////////////////////
	
	//create factory for returning different factories of code objects
	public abstract class FactoryFactory
	{
		public abstract ObjectFactory get_factory(string type);
	}
	
	//return concrete object like int var or while loop
	public abstract class ObjectFactory
	{
		public abstract CodeObject get_object(string type, string n, string v);
		
		public abstract string type();
	}
	
	//objects abstraction for structures loops variables
	public abstract class CodeObject
	{
		public abstract string get_text();
	}
	
	
	/*************FACTORY REALIZATION*************/
	
	
	public class Factory : FactoryFactory
	{
		public override ObjectFactory get_factory(string type)
		{
			if (type == "var") {
				return new VariableFactory();
			}
			else if (type == "struct") {
				return new StructureFactory();
			}
			else return null;
		} 
	}

	public class VariableFactory : ObjectFactory
	{		
		public override CodeObject get_object(string type, string n, string v)
		{
			if (type == "int")
			{
				return new IntVar(n, v);
			}
			else return null;
		}
		
		public override string type()
		{
			return "variable";
		}
	}
	
	public class StructureFactory : ObjectFactory
	{
		public override CodeObject get_object(string type, string n, string v)
		{
			return null;
		}
		
		public override string type()
		{
			return "structure";
		}
	}
	
	/*****************OBJECTS DATA*****************/
	
	public class VarData 
	{
		public string name;
		public string values;
		public VarData (string n, string v)
		{
			this.name = n;
			this.values = v;
		}
	}
	
	
	/*************OBJECTS REALIZATION*************/
	
	public class IntVar : CodeObject
	{
		public VarData data;
		public string type = "int";
		
		public IntVar(string n, string v)
		{
			this.data = new VarData(n, v);
		}
		
		public override string get_text()
		{
			return this.type+" "+this.data.name+" = "+this.data.values+";";
		}
	}
	
	
	/****************************************/
	/*              MAIN FORM               */
	/****************************************/
	
	
	public partial class MainForm : Form
	{
		public MainForm()
		{InitializeComponent();}
		
		public int latest = 0;
		
		public string row;
		public string[] separated = new string[10];

		public Factory tmpFactory = new Factory();
		public ObjectFactory tmpObjectFactory;
		public CodeObject tmpCodeObject;
		public CodeObject[] storage = new CodeObject[100];
		
		void RecognizeText(object sender, EventArgs e)
		{
			//string row is for the full logical block of speech
			row = this.inputLabel.Text;
			this.inputLabel.Text = "";
			
			separated = row.Split(' ');
			
			//get object factory
			this.tmpObjectFactory = this.tmpFactory.get_factory(this.separated[0]);
			
			
			if (this.tmpObjectFactory!=null)
			{
				//get concrete object: loop variable class etc
				this.tmpCodeObject = this.tmpObjectFactory.get_object(this.separated[1], this.separated[2], this.separated[4]);
				
				if (this.tmpCodeObject!=null){
					//save right part of code into the mass
					this.storage[this.latest] = this.tmpCodeObject; 
					this.latest++;
					
					//call foo to refresh code in text editor
					this.show_code();
						
				} else this.outputLabel.Text = "Unrecognized type of "+this.tmpObjectFactory.type();
				
			} else this.outputLabel.Text = "Unrecognized type of code objects";
			
		}
		
		public void show_code()
		{
			this.outputLabel.Text = "";
			
			for(int i=0; i<=this.latest; i++)
			{
				if (this.storage[i]!=null)
				{
					this.outputLabel.Text += this.storage[i].get_text();
					this.outputLabel.Text += '\n';
				}
			}
			
		}
	}
}
