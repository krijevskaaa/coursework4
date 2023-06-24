using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork_Kryzhevska
{
    class RegisterOperations: Form1
    {
        private double[] registers; // Приклад використання масиву як пам'яті
        

        public void Clear()
        {
            Array.Clear(registers, 0, registers.Length);
        }
        public RegisterOperations()
        {
            registers = new double[8]; // Ініціалізація пам'яті
        }
        

        public double LoadFromMemory(int number)
        {
            return registers[number]; // Завантаження даних з пам'яті за певною адресою
        }


        public void SE_REG(int number, double data)
        {
            registers[number] = data; // Запис даних до пам'яті за певною адресою
        }

       
    }
}
