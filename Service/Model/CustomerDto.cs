﻿namespace Service.Model;
public class CustomerDto
{
    public string CustomerId { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string? ContactName { get; set; }

    public string? Country { get; set; }

    public string? Phone { get; set; }

}
