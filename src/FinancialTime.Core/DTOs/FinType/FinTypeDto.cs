﻿using FinancialTime.Core.DTOs.FinOperation;

namespace FinancialTime.Core.DTOs.FinType;

public class FinTypeDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Budget { get; set; } = null!;

    public ICollection<FinOperationDto>? ListOperations { get; set; }
}