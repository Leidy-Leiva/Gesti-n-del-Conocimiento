using proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VDS.RDF.Parsing;
using VDS.RDF.Query;
using VDS.RDF.Query.Algebra;
using VDS.RDF.Query.Paths;
using VDS.RDF.Update;

namespace proyecto.Controllers
{
    public class InstitutoController : Controller
    {

        private static SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri("http://localhost:3030/Deporte/sparql"));

        // GET: Instituto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Catalogo()
        {
            // Se define una lista vacía para almacenar los estilos de lucha
            List<Estilo> listaE = new List<Estilo>();
            // Se realiza una consulta SPARQL al endpoint para obtener los datos de los estilos de lucha
            SparqlResultSet resultado = endpoint.QueryWithResultSet(
                   "PREFIX bd: <http://www.semanticweb.org/johana/ontologies/2023/4/InstitutoDefensaP#>" +
                   "PREFIX da: <https://www.wowman.org/index.php?id=1&type=get#>" +
                   "PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>" +
                   "PREFIX owl: <http://www.w3.org/2002/07/owl#>" +
                   "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>" +
                   "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>" +
                   "PREFIX xml: <http://www.w3.org/XML/1998/namespace/>" +
                   "Select ?nomE ?desE ?E " +
                   "where{ " +
                        "?E rdf:type bd:Estilo. " +
                        "?E bd:EstiloNombre ?nomE . " +
                        "?E bd:EstiloDescripcion ?desE . " +
                    "} "
                );

            foreach (var result in resultado.Results)
            {
                Estilo est = new Estilo();
                var dato = result.ToList();
                est.NomEstilo = dato[0].Value.ToString();
                est.DesEstilo = dato[1].Value.ToString();
                est.Identificador = dato[2].Value.ToString();
                listaE.Add(est);
            }
            return View(listaE);
        }

        public ActionResult Maestro()
        {
            // Se define una lista vacía para almacenar los maestros
            List<Maestro> listaM = new List<Maestro>();
            // Se realiza una consulta SPARQL al endpoint para obtener los datos de los maestros
            SparqlResultSet resultado = endpoint.QueryWithResultSet(
                   "PREFIX bd:<http://www.semanticweb.org/johana/ontologies/2023/4/InstitutoDefensaP#>" +
                   "PREFIX da:<https://www.wowman.org/index.php?id=1&type=get#>" +
                   "PREFIX xsd:<http://www.w3.org/2001/XMLSchema#>" +
                   "PREFIX owl:<http://www.w3.org/2002/07/owl#>" +
                   "PREFIX rdf:<http://www.w3.org/1999/02/22-rdf-syntax-ns#>" +
                   "PREFIX rdfs:<http://www.w3.org/2000/01/rdf-schema#>" +
                   "PREFIX xml:<http://www.w3.org/XML/1998/namespace/>" +
                   "SELECT ?nom ?ape (str(?ed) as ?edad) ?bio " +
                   " ?desE ?nomC " +
                   "WHERE{ " +
                        "?x rdf:type bd:Maestro . " +
                        "?x bd:Nombre ?nom . " +
                        "?x bd:Apellido ?ape . " +
                        "?x bd:Edad ?ed. " +
                        "?x bd:Biografia ?bio " +
                    "} "
                );

            foreach (var result in resultado.Results)
            {
                Maestro pro = new Maestro();
                var dato = result.ToList();
                pro.Nombre = dato[0].Value.ToString();
                pro.Apellido = dato[1].Value.ToString();
                pro.Edad = dato[2].Value.ToString();
                pro.Biografia = dato[3].Value.ToString();
                listaM.Add(pro);
            }
            return View(listaM);
        }

        public ActionResult MostrarAlumnos()
        {
            // Se define una lista vacía para almacenar los maestros
            List<Alumno> listaAlumnos = new List<Alumno>();
            // Se realiza una consulta SPARQL al endpoint para obtener los datos de los maestros
            SparqlResultSet resultado = endpoint.QueryWithResultSet(
                   "PREFIX bd:<http://www.semanticweb.org/johana/ontologies/2023/4/InstitutoDefensaP#>" +
                   "PREFIX da:<https://www.wowman.org/index.php?id=1&type=get#>" +
                   "PREFIX xsd:<http://www.w3.org/2001/XMLSchema#>" +
                   "PREFIX owl:<http://www.w3.org/2002/07/owl#>" +
                   "PREFIX rdf:<http://www.w3.org/1999/02/22-rdf-syntax-ns#>" +
                   "PREFIX rdfs:<http://www.w3.org/2000/01/rdf-schema#>" +
                   "PREFIX xml:<http://www.w3.org/XML/1998/namespace/>" +
                   "SELECT (STR(?id) AS ?NumeroIdentificacion) ?Nombre ?Apellido (STR(?ed) AS ?Edad) ?Sexo " +

                   "WHERE{ " +
                        "?alumno rdf:type bd:Alumno . " +
                        "?alumno bd:NumIdentificacion ?id. " +
                        "?alumno bd:Nombre ?Nombre . " +
                        "?alumno bd:Apellido ?Apellido . " +
                        "?alumno bd:Edad ?ed . " +
                        "?alumno bd:Sexo ?Sexo . " +
                    "} "
                );

            foreach (var result in resultado.Results)
            {
                Alumno alumno = new Alumno();
                var dato = result.ToList();
                alumno.NumIdentificacion = dato[0].Value.ToString();
                alumno.Nombre = dato[1].Value.ToString();
                alumno.Apellido = dato[2].Value.ToString();
                alumno.Edad = dato[3].Value.ToString();
                alumno.Sexo = dato[4].Value.ToString();
                listaAlumnos.Add(alumno);
            }
            return View(listaAlumnos);
        }



        public ActionResult AlumnoEstilo()
        {
            // Se define una lista vacía para almacenar los estilos de lucha
            List<Estilo> listaE = new List<Estilo>();
            // Se realiza una consulta SPARQL al endpoint para obtener los datos de los estilos de lucha
            SparqlResultSet resultado = endpoint.QueryWithResultSet(
                   "PREFIX bd: <http://www.semanticweb.org/johana/ontologies/2023/4/InstitutoDefensaP#>" +
                   "PREFIX da: <https://www.wowman.org/index.php?id=1&type=get#>" +
                   "PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>" +
                   "PREFIX owl: <http://www.w3.org/2002/07/owl#>" +
                   "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>" +
                   "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>" +
                   "PREFIX xml: <http://www.w3.org/XML/1998/namespace/>" +
                   "ELECT ? NombreAlumno ? NombreEstilo " +
                   "where{ " +
                        " ?alumno bd:Practica? estilo . " +
                        "?alumno bd:Nombre? NombreAlumno . " +
                        "?estilo bd:EstiloNombre? NombreEstilo ." +
                    "} "+
                     "ORDER BY ? NombreAlumno"
                );

            foreach (var result in resultado.Results)
            {
                Estilo est = new Estilo();
                var dato = result.ToList();
                est.NomEstilo = dato[0].Value.ToString();
                est.DesEstilo = dato[1].Value.ToString();
                est.Identificador = dato[2].Value.ToString();
                listaE.Add(est);
            }
            return View(listaE);
        }

        public ActionResult RegistrarAlumnos()
        {
            SparqlUpdateParser parser = new SparqlUpdateParser();
            SparqlParameterizedString cmdString = new SparqlParameterizedString();
            cmdString.CommandText = "LOAD <http://dbpedia.org/resource/Southampton> INTO <http://localhost:3030/InstitutoDP>";

            if (Request.HttpMethod == "POST")
            {
                SparqlRemoteUpdateEndpoint endpointUp = new SparqlRemoteUpdateEndpoint(new Uri("http://localhost:3030/InstitutoDP/update"));

                // Obtener los datos ingresados por el usuario desde la solicitud POST

                string NumIdentificacion = Request.Form["NumIdentificacion"];
                string Nombre = Request.Form["Nombre"];
                string Apellido = Request.Form["Apellido"];
                string Edad = Request.Form["Edad"];
                string Sexo = Request.Form["Sexo"];

                // Construir la consulta SPARQL para insertar el nuevo alumno
                /*string consulta =
                    "PREFIX xsd: <http://www.w3.org/2001/XMLSchema#> " +
                    "PREFIX owl: <http://www.w3.org/2002/07/owl#> " +
                    "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                    "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> " +
                    "PREFIX bd: <http://www.semanticweb.org/stwar/ontologies/2023/4/InstitutoDefensaPersonal#> " +
                    "INSERT DATA{  " +
                    "bd:'" + NumIdentificacion + "' bd:NumIdentificacion '" + NumIdentificacion + "' . " +
                    "bd:'" + NumIdentificacion + "' bd:Nombre '" + Nombre + "' .  " +
                    "bd:'" + NumIdentificacion + "' bd:Apellido '" + Apellido + "' . " +
                    "bd:'" + NumIdentificacion + "' bd:Edad '" + Edad + "' . " +
                    "bd:'" + NumIdentificacion + "' bd:Sexo '" + Sexo + "' . " +
                    "}";*/
                string consulta =
                  
                   "PREFIX da:<https://www.wowman.org/index.php?id=1&type=get#>" +
                   "PREFIX xsd:<http://www.w3.org/2001/XMLSchema#>" +
                   "PREFIX owl:<http://www.w3.org/2002/07/owl#>" +
                   "PREFIX rdf:<http://www.w3.org/1999/02/22-rdf-syntax-ns#>" +
                   "PREFIX rdfs:<http://www.w3.org/2000/01/rdf-schema#>" +
                   "PREFIX xml:<http://www.w3.org/XML/1998/namespace/>" +
                        @"PREFIX xsd: <http://www.w3.org/2001/XMLSchema#> 
                        PREFIX owl: <http://www.w3.org/2002/07/owl#> 
                        PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> 
                        PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> 
                       PREFIX bd:<http://www.semanticweb.org/johana/ontologies/2023/4/InstitutoDefensaP#>
                        INSERT DATA {  
                            bd:" + NumIdentificacion + @" bd:NumIdentificacion " + NumIdentificacion + @" ;  
                            bd:" + NumIdentificacion + @" bd:Nombre '" + Nombre + @"' ;  
                            bd:" + NumIdentificacion + @" bd:Apellido '" + Apellido + @"' ;  
                            bd:" + NumIdentificacion + @" bd:Edad " + Edad + @" ;  
                            bd:" + NumIdentificacion + @" bd:Sexo '" + Sexo + @"' . 
                        }";

                // Formatear la consulta con los valores de los parámetros
                consulta = string.Format(NumIdentificacion, Nombre, Apellido, Edad, Sexo);

                // Ejecutar la consulta SPARQL para insertar el nuevo alumno

                endpointUp.Update(consulta);

                // Redirigir al usuario a una vista de confirmación o a la lista de alumnos actualizada
                return RedirectToAction("Alumnos");
            }
            return View();
        }

        /*public ActionResult RegistrarAlumnos()
        {
            if (Request.HttpMethod == "POST")
            {
                // Obtener los datos ingresados por el usuario desde la solicitud POST
                string NumIdentificacion = Request.Form["NumIdentificacion"];
                string Nombre = Request.Form["Nombre"];
                string Apellido = Request.Form["Apellido"];
                string Edad = Request.Form["Edad"];
                string Sexo = Request.Form["Sexo"];

                try
                {
                    // Construir la consulta SPARQL para insertar el nuevo alumno
                    string consulta =
                        @"PREFIX xsd: <http://www.w3.org/2001/XMLSchema#> 
                PREFIX owl: <http://www.w3.org/2002/07/owl#> 
                PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> 
                PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> 
                PREFIX bd: <http://www.semanticweb.org/stwar/ontologies/2023/4/InstitutoDefensaPersonal#> 
                INSERT DATA {  
                    bd:" + NumIdentificacion + @" bd:NumIdentificacion '" + NumIdentificacion + @"' ;  
                    bd:" + NumIdentificacion + @" bd:Nombre '" + Nombre + @"' ;  
                    bd:" + NumIdentificacion + @" bd:Apellido '" + Apellido + @"' ;  
                    bd:" + NumIdentificacion + @" bd:Edad '" + Edad + @"' ;  
                    bd:" + NumIdentificacion + @" bd:Sexo '" + Sexo + @"' . 
                }";

                    // Crear el objeto SparqlUpdateCommandSet y agregar el comando de actualización
                    SparqlUpdateCommandSet commandSet = new SparqlUpdateCommandSet();
                    commandSet.AddCommand(consulta);

                    // Ejecutar la consulta SPARQL para insertar el nuevo alumno
                    SparqlRemoteUpdateEndpoint endpointUp = new SparqlRemoteUpdateEndpoint(new Uri("http://localhost:3030/InstitutoDP"));
                    endpointUp.Update(commandSet);

                    // Redirigir al usuario a una vista de confirmación o a la lista de alumnos actualizada
                    return RedirectToAction("Alumnos");
                }
                catch (System.Net.WebException ex)
                {
                    // Manejar la excepción en caso de error
                    // Puedes agregar código aquí para registrar el error o mostrar un mensaje de error al usuario
                    return View("Error");
                }
            }

            return View();
        }*/

        public ActionResult DetalleEstilos(string identificador)
        {
            Estilo estilo = new Estilo();
            SparqlResultSet resultado = endpoint.QueryWithResultSet(
                   "PREFIX bd: <http://www.semanticweb.org/johana/ontologies/2023/4/InstitutoDefensaP#> " +
                   "PREFIX da: <https://www.wowman.org/index.php?id=1&type=get#> " +
                   "PREFIX xsd: <http://www.w3.org/2001/XMLSchema#> " +
                   "PREFIX owl: <http://www.w3.org/2002/07/owl#> " +
                   "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> " +
                   "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                   "PREFIX xml: <http://www.w3.org/XML/1998/namespace/> " +
                   "SELECT ?NombreEstilo ?Descripcion (concat(?nom, ' ',?ape) AS ?Instructor) ?cat ?estilo " +
                   "WHERE{ " +
                        "?estilo bd:Es_Enseñado_Por ?maestro . " +
                        "?estilo bd:SeEnfocaEn ?categoria . " +
                        "?estilo bd:EstiloNombre ?NombreEstilo . " +
                        "?estilo bd:EstiloDescripcion ?Descripcion . " +
                        "?maestro bd:Nombre ?nom . " +
                        "?maestro bd:Apellido ?ape . " +
                        "?categoria bd:CatNombre ?cat. " +
                        "FILTER (?estilo = <" + identificador + ">)" +
                    "} "
                );
            var datos = resultado.Results.Single().ToList();

            estilo.NomEstilo = datos[0].Value.ToString();
            estilo.DesEstilo = datos[1].Value.ToString();
            estilo.Maestro = datos[2].Value.ToString();
            estilo.Categoria = datos[3].Value.ToString();
            estilo.Identificador = datos[4].ToString();
            return View(estilo);
        }

    }
}