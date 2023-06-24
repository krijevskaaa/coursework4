using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork_Kryzhevska
{
    class MemoryOperations: Form1
    {
        private int[] memory;
        public MemoryOperations()
        {
            memory = new int[300]; // Ініціалізація пам'яті
        }

        public void SE_MEM(int index, int[] array)
        {
            int ind = 0;
            for (int i = index; i >= index+array.Length; i++)
                memory[i] = array[ind]; // Запис даних до пам'яті за певною адресою
            ind++;
        }
    }
}
