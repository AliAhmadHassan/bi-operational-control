using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ServiceNotification.Msmq
{
    public class ServiceMsmq
    {
        MessageQueueTransaction transction;

        public void Enqueue<T>(T mensagem, string fila, MessageQueueTransaction transction = null)
        {
            Type type = typeof(T);

            System.Messaging.Message msg = new System.Messaging.Message(mensagem, new BinaryMessageFormatter());
            msg.Body = mensagem;

            MessageQueue msgQ = new MessageQueue(fila);
            msgQ.Send(msg, transction);
        }

        public T Dequeue<T>(string fila, MessageQueueTransaction transction = null)
        {
            Type type = typeof(T);

            using (MessageQueue messageQueue = new MessageQueue(fila))
            {
                messageQueue.Formatter = new BinaryMessageFormatter();

                Message msg = new Message();
                try
                {
                    if (transction != null)
                        msg = messageQueue.Receive(new TimeSpan(0, 0, 0, 1), transction);
                    else
                        msg = messageQueue.Receive(new TimeSpan(0, 0, 0, 1));

                    return (T)msg.Body;
                }
                catch (Exception ex)
                {
                    return (T)Convert.ChangeType(null, typeof(T));
                }
            }
        }

        public MessageQueueTransaction BeginTransaction()
        {
            transction = new MessageQueueTransaction();
            transction.Begin();
            return transction;
        }

        public void CommmitTransaction()
        {
            transction.Commit();
            transction.Dispose();
            transction = null;
        }

        public void RollbackTransction()
        {
            transction.Abort();
            transction.Dispose();
            transction = null;
        }
    }
}