using System.Diagnostics;
using System.Net.Mail;

namespace CustomersManagement;

public class ValidationResult
{
    public bool IsValid { get; set; }
    public string Message { get; set; }
    public string FieldName { get; set; }

    public ValidationResult(bool isValid, string message = "", string fieldName = "")
    {
        IsValid = isValid;
        Message = message;
        FieldName = fieldName;
    }
}


public static class CustomerValidator
{
    public static ValidationResult Validate(string firstName, string lastName, string email, string phone)
    {
        //clean up parameters 
        firstName = firstName.Trim() ?? string.Empty;
        lastName = lastName.Trim() ?? string.Empty;
        email = email.Trim() ?? string.Empty;
        phone = phone.Trim() ?? string.Empty;

        //verify for mandatory fields 
        if (string.IsNullOrWhiteSpace(firstName))
            return new ValidationResult(false, "FirstName input is mandatory", "FirstName");

        if (string.IsNullOrWhiteSpace(lastName))
            return new ValidationResult(false, "LastName input is mandatory", "LastName");

        if (string.IsNullOrWhiteSpace(email))
            return new ValidationResult(false, "Email is mandatory", "Email");

        //validate email input
        try
        {
            var emailAddress = new MailAddress(email);
        }
        catch (Exception ex)
        {
            Trace.TraceError("Error when validating the email {0}", ex.Message);
            return new ValidationResult(false, "Email is in the wrong fromat.", "Email");
        }

        //validate the length 
        if (firstName.Length > 50)
            return new ValidationResult(false, "FirstName must be max. of 50 chars", "FirstName");

        if (lastName.Length > 50)
            return new ValidationResult(false, "LastName must be max. of 50 chars", "LastName");

        if (email.Length > 100)
            return new ValidationResult(false, "Email must be max. 100 of chars", "Email");

        if (!string.IsNullOrEmpty(phone) && phone.Length > 20)
            return new ValidationResult(false, "Phone must be max. of 20 chars", "Phone");

        //validate the phone 
        if (!string.IsNullOrWhiteSpace(phone) && !phone.All(char.IsDigit))
            return new ValidationResult(false, "Phone must be only digits", "Phone");

        return new ValidationResult(true);
    }
}
