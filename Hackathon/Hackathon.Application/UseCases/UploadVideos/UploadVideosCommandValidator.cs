using FluentValidation;

namespace Hackathon.Application.UseCases.UploadVideos
{
    internal sealed class UploadVideosCommandValidator : AbstractValidator<UploadVideosCommand>
    {
        public UploadVideosCommandValidator()
        {
            RuleFor(x => x.InputFileName).NotEmpty();
            RuleFor(x => x.InputFileName).NotNull();

            RuleFor(x => x.InputFileName).Must(x => x.EndsWith(".mp4")).WithMessage("The file must be a mp4 video");
        }
    }
}
