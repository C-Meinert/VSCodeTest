using System;

namespace testNetCoreApp.V2.Dtos
{
    /// <summary>
    /// Simple Data Transfer Object
    /// </summary>
    public class SimpleDto
    {
        /// <summary>
        /// Object identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///  some property 
        /// </summary>
        public string prop1 { get; set; }

        /*
         * Add addition properties here
         */
    }
}