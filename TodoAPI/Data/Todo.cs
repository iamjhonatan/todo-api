using System.ComponentModel.DataAnnotations.Schema;

namespace TodoAPI.Data;

// record: lightweight, immutable, read-only data type. can only be started from a constructor
[Table("Todos")]
public record Todo(int Id, string Activity, string Status);
