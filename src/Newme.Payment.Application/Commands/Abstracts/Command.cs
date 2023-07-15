using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using FluentValidation.Results;

namespace Newme.Payment.Application.Commands;

public abstract class Command
{
    protected Command()
    {
        ValidationResult = new ValidationResult();
    }
    
    [JsonIgnore]
    public ValidationResult ValidationResult { get; protected set; }

    public virtual bool IsValid()
    {
        return true;
    }
}