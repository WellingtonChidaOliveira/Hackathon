using Hackathon.Domain.Util;
using MediatR;

namespace Hackathon.Application.UseCases.DownloadZipVideo
{
    internal sealed class DowloadZipVideoCommandHandler : IRequestHandler<DowloadZipVideoCommand, Result>
    {
        public async Task<Result> Handle(DowloadZipVideoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string zipFilePath = request.pathZip;
                string destinationDirectory = "Dowload/Caminho_para_o_seu_arquivo_local.zip";

                string destinationFilePath = Path.Combine(destinationDirectory, Path.GetFileName(zipFilePath));

                File.Copy(zipFilePath, destinationFilePath, true);

                if (File.Exists(destinationFilePath))
                {
                    return new Result { Success = true, Message = destinationDirectory, Data = null };
                }
                else
                {
                    return new Result { Success = false, Message = destinationDirectory, Data = null };
                }
            }
            catch (Exception ex)
            {
                return new Result { Success = false, Message = ex.Message, Data = null };
            }
        }
    }
}
