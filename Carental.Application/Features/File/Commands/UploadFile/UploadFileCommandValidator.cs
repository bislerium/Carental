using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carental.Application.Features.File.Commands.UploadFile
{
    internal class UploadFileCommandValidator: AbstractValidator<UploadFileCommand>
    {
        private const decimal MAX_FILE_SIZE_IN_MB = 1.5m;

        public UploadFileCommandValidator() 
        {
            RuleFor(x => x.File)
                .Must(IsFileEmpty)
                .WithMessage("File cannot be empty.")
                .Must(IsFileSizeValid)
                .WithMessage($"File must not exceed {MAX_FILE_SIZE_IN_MB}MB.");            
        }

        private bool IsFileSizeValid(IFormFile file)
        {
            return file.Length < MAX_FILE_SIZE_IN_MB * 1024 * 1024;
        }

        private bool IsFileEmpty(IFormFile file)
        {
            return !(file is null || file.Length == 0);
        }
    }
}
