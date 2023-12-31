﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialTime.Core.Models;

public class FinOperation
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Value { get; set; }

    public DateTime Date { get; set; }

    public bool IsDelete { get; set; }

    [ForeignKey(nameof(FinType))]
    public int FinTypeId { get; set; }

    public FinType FinType { get; set; } = null!;
}