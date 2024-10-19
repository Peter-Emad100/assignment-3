using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace assignment_3
{
    public class Cache<Tx, Ty>:IEnumerable where Tx : IComparable<Tx> where Ty :IComparable<Ty>
    {

        private Tx[] tx= new Tx[15];
        private Ty[] ty = new Ty[15];
        private int[] freq = new int[15];
        int index = 0;
        public void add(Tx tx1,Ty ty2)
        {
            if (index == 15)
            {
                int temp = Array.IndexOf(freq, freq.Min());
                tx[temp] = tx1;
                ty[temp] = ty2;
            }
            else
            {
                tx[index] = tx1;
                ty[index] = ty2;
                index++;
            }
        }
        public Ty retrieve(Tx tx1)
        {
            for (int i = 0; i <= index; i++)
            {
                if (tx[i].CompareTo(tx1)==0)
                {
                    return ty[i];
                }
            }
            return (default);
        }
        public void delete(Tx tx1)
        {
            for (int i = 0; i < index; i++)
            {
                if (tx[i].CompareTo(tx1) == 0)
                {
                    tx[i] = default;
                    ty[i] = default;
                    freq[i] = -1;
                }
            }
        }
        public Tx getValueByindex(int ind)
        {
            return tx[ind];
        }
        public Ty getKeyByindex(int ind)
        {
            return ty[ind];
        }
        public IEnumerator GetEnumerator() => new InternalCache(this);
        public class InternalCache:IEnumerator
        {
            int innerIndex = -1;
            Cache<Tx, Ty> cac;
            public InternalCache(Cache<Tx,Ty> ca) {
                cac = ca;
            }
            
            public bool MoveNext()
            {
                while (++innerIndex < cac.index && cac.tx[innerIndex].CompareTo(default) == 0) ;
                
                return innerIndex <cac.index;
            }
            public void Reset()
            {
                innerIndex = -1;
            }
            public object Current
            {
                get
                {
                        return $"tkey          {cac.tx[innerIndex]} tvalue        {cac.ty[innerIndex]}";
                }
            }
        }
    }
}
