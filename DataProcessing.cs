using System;
using System.Collections.Generic;
using System.Text;
using CourseWork_Kryzhevska;

namespace CourseWork_Kryzhevska
{
    class DataProcessing: Form1
    {
        public double ADD(double A2, double A3)
        {
            return A2 + A3; // Приклад операції обробки даних - додавання чисел
        }
        public double SUB(double A2, double A3)
        {
            return  A2 - A3; 
        }

        public double MUL(double A2, double A3)
        {
            return  A2 * A3; 
        }
        public double INC(double i)
        {
            return i+1;
        }
        public int DIV( int A2, int A3)
        {
            /*if (A3 == 0)
            {
                return 0;
            }*/
            return A2 / A3;
        }
        public double DIVF(double A2, double A3)
        {
            /*if (A3 == 0)
            {
                return 0;
            }*/
            return A2 / A3;
        }
        public int MOD( int A2, int A3)
        {
            return  A2 % A3;
        }
        public int AND(int A2, int A3)
        {
            return A2 & A3;
        }
        public bool OR( bool A2, bool A3)
        {
            /*if ()*/
            return A2 | A3;
        }
        public int NOT( int A2)
        {
            return  -A2;
        }
        public int XOR( int A2, int A3)
        {
            return A2 ^ A3;
        }
        public bool JE( string A2, string A3)
        {
            if (A2 == A3) 
            {
                return true;
            }
            return false;
            
        }
        public bool JG(int A2, int A3)
        {
            if (A2 > A3)
            {
                return true;
            }
            return false;
        }
        public bool JL( double A2, double A3)
        {
            if (A2 < A3)
            {
                return true;
            }
            return false;
        }
        public bool JNE(string A2, string A3)
        {
            if (A2 != A3)
            {
                return true;
            }
            return false;
        }
        
        public void EXIT( int A2, int A3)
        {
            ;
        }
        public int JMP(int A1)
        {
            return A1;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DataProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.ClientSize = new System.Drawing.Size(735, 600);
            this.Name = "DataProcessing";
            this.Load += new System.EventHandler(this.DataProcessing_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void DataProcessing_Load(object sender, EventArgs e)
        {

        }



        /*public int SET_REG(int A1, int A2, int A3)
{
return a / b;
}
public int SE_MEM(int A1, int A2, int A3)
{
return a / b;
}
public int MOVE_TO_MEM(int A1, int A2, int A3)
{
return a / b;
}*/
    }
}
