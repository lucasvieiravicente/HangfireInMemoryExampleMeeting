using Hangfire;
using System;

namespace ExemploInMemoryMeetingHangfire
{
    public class Exemplos
    {
        public Exemplos()
        {
            //Processamento "ative e esqueça"
            string jobId = BackgroundJob.Enqueue(() => Console.WriteLine("Ative-e-esqueça!"));

            //Processamento agendado
            BackgroundJob.Schedule(() => Console.WriteLine("Agendado!"), TimeSpan.FromDays(7));
            
            //Processamento recorrente
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Recorrente!"), Cron.Daily);

            //Processamento "continuado"
            BackgroundJob.ContinueJobWith(jobId, () => Console.WriteLine("Continuação de jobId!"));


            /*
             
            -- Processos da versão PRO --


            Processamento em lote:
            
            var batchId = BatchJob.StartNew(x =>
            {
                x.Enqueue(() => Console.WriteLine("Job 1"));
                x.Enqueue(() => Console.WriteLine("Job 2"));
            });

            ------------------------------------------------------------------------

            Processamento em lote "continuado":

            BatchJob.ContinueBatchWith(batchId, x =>
            {
                x.Enqueue(() => Console.WriteLine("Last Job"));
            });

            */
        }
    }
}
