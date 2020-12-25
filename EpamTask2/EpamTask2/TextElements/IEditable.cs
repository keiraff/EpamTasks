using System;
using System.Collections.Generic;
using System.Text;

namespace EpamTask2.TextElements
{
    public interface IEditable<T>
    {
        public void Create(T item);//Adding object to the collection
        public void Create(string value);//Creating object by string value and adding to the collection
        public void Update(T obj1, T obj2);//Replacing object from the collection by another one
        public void Update(T obj, string line);//Replacing object from the collection by object created from string value
        public void Update(string line1, string line2);//Replacing objects with first string value by objects with the second 
        bool Delete(T item);//deleting object from the collection
        bool Delete(int index);//deleting object from the collection by index
        bool Delete(string value);//deleting object from the collection by string value
        //string Value { get; }
    }
}
