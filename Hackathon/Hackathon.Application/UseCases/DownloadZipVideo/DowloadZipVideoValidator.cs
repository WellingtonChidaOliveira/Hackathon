using FluentValidation;

namespace Hackathon.Application.UseCases.DownloadZipVideo
{
    public class DowloadZipVideoValidator: AbstractValidator<DowloadZipVideoCommand>
    {
        public DowloadZipVideoValidator()
        {
            RuleFor(x => x.pathZip).NotEmpty();
            RuleFor(x => x.pathZip).NotNull();
        }
    }
}
