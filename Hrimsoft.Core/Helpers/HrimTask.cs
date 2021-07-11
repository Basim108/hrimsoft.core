using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hrimsoft.Core.Helpers
{
    public static class HrimTask
    {
        /// <summary>
        /// Wrapper around the <see cref="Task.WhenAll"/> that throws <see cref="AggregateException"/>
        /// </summary>
        /// <param name="tasks"></param>
        /// <exception cref="AggregateException"></exception>
        public static async Task WhenAll(IEnumerable<Task> tasks)
        {
            var whenAllTask = Task.WhenAll(tasks);
            try {
                await whenAllTask;
            }
            catch(Exception) {
                // suppress this exception as it's only one from possible several exceptions occured in these tasks
                // aggregate exception that wraps all occured exceptions is in whenAllTask.Exception; 
            }
            if(whenAllTask.Exception != null)
                throw whenAllTask.Exception;
        }
        
        /// <summary>
        /// Wrapper around the <see cref="Task.WhenAll"/> that throws <see cref="AggregateException"/>
        /// </summary>
        /// <param name="tasks"></param>
        /// <exception cref="AggregateException"></exception>
        public static async Task WhenAll(params Task[] tasks)
        {
            var whenAllTask = Task.WhenAll(tasks);
            try {
                await whenAllTask;
            }
            catch(Exception) {
                // suppress this exception as it's only one from possible several exceptions occured in these tasks
                // aggregate exception that wraps all occured exceptions is in whenAllTask.Exception; 
            }
            if(whenAllTask.Exception != null)
                throw whenAllTask.Exception;
        }
    }
}