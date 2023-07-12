using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Text;
using Newtonsoft.Json;

namespace ServicioPrueba
{
    public partial class Service1 : ServiceBase
    {

        // Establece conexion con bb.dd.    
        Dat datos = new Dat();

        public Service1()
        {
            InitializeComponent();
        }

        

        private HttpListener listener;
        private CancellationTokenSource cts;

        protected override void OnStart(string[] args)
        {
                           

            // Establece la dirección IP y el puerto en los que el servidor escuchará las solicitudes
            string ipAddress = "127.0.0.1";
            int port = 8080;

            // Crea una instancia del objeto HttpListener
            listener = new HttpListener();
            listener.Prefixes.Add($"http://{ipAddress}:{port}/");
            listener.Start();

            // Crea un CancellationTokenSource para permitir la cancelación de la operación asincrónica
            cts = new CancellationTokenSource();

            // Inicia el manejo de solicitudes de forma asincrónica
            Task.Run(() => HandleRequestsAsync(cts.Token));


        }

        protected override void OnStop()
        {

            // Detiene el manejo de solicitudes y cancela la operación asincrónica
            cts.Cancel();
            listener.Stop();
            listener.Close();


        }

        private async Task HandleRequestsAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // Espera una solicitud de forma asincrónica
                HttpListenerContext context = await listener.GetContextAsync();

                // Verifica el método de la solicitud
                if (context.Request.HttpMethod == "POST")
                //  if (context.Request.HttpMethod == "GET")
                {
                    // Establece el tipo de contenido de la respuesta como XML
                    context.Response.ContentType = "application/xml";

                    // Construye el XML de ejemplo
                    string xmlResponse = "<root><message>Hola mundo</message></root>";

                    // Convierte el XML en bytes
                    byte[] buffer = Encoding.UTF8.GetBytes(xmlResponse);

                    // Obtiene el flujo de salida de la respuesta
                    Stream output = context.Response.OutputStream;

                    // Escribe los bytes en el flujo de salida
                    await output.WriteAsync(buffer, 0, buffer.Length, cancellationToken);

                    // Escribe los bytes del JSON en el flujo de salida
                    
                    // Establecer el encabezado Content-Type
                    context.Response.ContentType= "text/JSON";
                    //get a JSON from the getJSON method and send it to the web browser                   
                    

                    // Serializar el objeto JSON y enviarlo al navegador                    
                    return Json(datos.getJSON(), JsonRequestBehavior.AllowGet);

 

                    // Cierra el flujo de salida
                    output.Close();
                }

                // Cierra la respuesta
                context.Response.Close();
            }
        }

       

    }
}
    
