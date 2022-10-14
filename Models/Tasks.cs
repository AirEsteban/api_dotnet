using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

public class Tasks
{
    public Guid TaskId {get;set;}
    public Guid CategoryId {get;set;}
    public string Title {get;set;}
    public string Description {get;set;}
    public Priority Priority {get;set;}
    public DateTime CreationDate {get;set;}    
    public virtual Category Category {get;set;}
    public string Resumee {get;set;}
}

public enum Priority
{
    Low,
    Medium,
    High
}