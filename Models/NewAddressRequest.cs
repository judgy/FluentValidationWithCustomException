﻿namespace FluentValidationWithCustomException.Models;

public class NewAddressRequest
{
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public bool IsForeignAddress { get; set; }
}