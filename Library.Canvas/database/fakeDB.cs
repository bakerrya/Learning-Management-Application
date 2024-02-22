using Library.Canvas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Canvas.database
{
    public static class fakeDB
    {
        public static List<Person> People
        {
            get
            {
                return new List<Person>();
            }

        }

        public static List<Course> Courses 
        { 
            get 
            { 
                return new List<Course>(); 
            } 
        }

    }
        
}
