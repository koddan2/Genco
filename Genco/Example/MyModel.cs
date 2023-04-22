// <auto-generated>
//     This file is generated by a tool.
// </auto-generated>

using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

#nullable enable

namespace Genco.Example
{
    /// <summary>
    /// This is a generated class.
    /// The tool used to generate this file is called Genco.
    /// </summary>
    
    public partial record MyModel([property: Required, Range(0, 100)] int Id, bool Important = true)
    {
        

        [MaxLength(0xff)]
        public string? Name { get; init; }
        
        public DateTime CreatedAt { get; } = DateTime.Now;
    }
}