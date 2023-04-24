    public class AccesoDatos
    {

        private SqlConnection conexion; // <-- que se utiliza para establecer una conexión a una base de datos de SQL Server
        private SqlCommand comando; // <-- se utiliza para representar una instrucción SQL que se va a ejecutar en una base de datos de SQL Server
        private SqlDataReader lector; // <-- se utiliza para leer los datos de una base de datos de SQL Server mediante una conexión abierta

      
        public SqlDataReader Lector // <-- Esta es una propiedad de solo lectura de tipo SqlDataReader
        {
            get { return lector; } // <-- La propiedad permite que se acceda al objeto lector desde fuera de la clase
        }

        public AccesoDatos() //<-- El costructor crea una instancia de la clase
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true"); //<-- Se crea una instancia de la clase SqlConnection con una cadena de conexión a una base de datos de SQL Server, el nombre del servidor (".\SQLEXPRESS"), el nombre de la base de datos ("CATALOGO_DB") y el uso de seguridad integrada ("integrated security=true"). Esta cadena de conexión se utiliza para establecer la conexión a la base de datos.
            comando = new SqlCommand(); //<-- Se crea una instancia de la clase SqlCommand. Esta instancia se utilizará para ejecutar comandos SQL en la base de datos
        }

        public void setearConsulta(string consulta) //<-- Se utiliza para establecer la consulta SQL que se ejecutará en la base de datos, la función toma un parámetro "consulta" que contiene la consulta SQL a ejecutar.
        {
            comando.CommandType = System.Data.CommandType.Text; //<-- Se establece el tipo de comando "comando" como "Text" utilizando la propiedad "CommandType" de "comando", esto significa que el "comando" que se ejecutará será un comando SQL en formato de texto.
            comando.CommandText = consulta; //<-- Esta línea establece la consulta que se ejecutará en la base de datos. El parámetro de entrada "consulta" se utiliza para establecer el valor de la propiedad "CommandText" del objeto "comando".
        }

        public void ejecutarLectura() // <--  Este método no tiene parámetros de entrada y no devuelve nada, su propósito es simplemente ejecutar una consulta en la base de datos.
        {
            comando.Connection= conexion; //<-- Esta línea establece la conexión que se utilizará para ejecutar la consulta. Se establece la conexión en el objeto "comando", contiene la consulta SQL que se desea ejecutar.
            try
            {
                conexion.Open(); //<-- se utiliza el método "Open" del objeto "conexion" para abrir la conexión a la base de datos.
                lector = comando.ExecuteReader(); //<-- Se llama al método "ExecuteReader" del objeto "comando" para ejecutar la consulta y se almacenan los resultados en un objeto "lector".
            }
            catch (Exception ex) //<-- En caso de que ocurra una excepción durante la ejecución de la consulta, se captura la excepción y se lanza de nuevo utilizando la sentencia "throw ex".
            {

                throw ex;
            }
        
        }

        public void ejecutarAccion() //<-- El método "ejecutarAccion", el cual no tiene parámetros de entrada y no devuelve nada. El propósito de este método es ejecutar una acción en la base de datos, como una actualización, eliminación o inserción de datos.
        {
            comando.Connection= conexion; //<-- Esta línea establece la conexión que se utilizará para ejecutar la consulta. Se establece la conexión en el objeto "comando", contiene la consulta SQL que se desea ejecutar.

            try
            {
                conexion.Open(); //<-- Se utiliza el método "Open" del objeto "conexion" para abrir la conexión a la base de datos. 
                comando.ExecuteNonQuery(); //<-- Se llama al método "ExecuteNonQuery" del objeto "comando" para ejecutar la acción y se almacena el número de filas afectadas en una variable que no se utiliza en esta función.
            }
            catch (Exception ex) //<-- En caso de que ocurra una excepción durante la ejecución de la acción, se captura la excepción y se lanza de nuevo utilizando la sentencia "throw ex".
            {

                throw ex;
            }
        }

        public void setearParametro(string nombre, object valor) //<--  El método "setearParametro", que tiene dos parámetros de entrada: "nombre", que es una cadena que representa el nombre del parámetro, y "valor", que es el valor que se va a asignar al parámetro. Este método no devuelve nada y se utiliza para establecer los parámetros de una consulta SQL.
        {
            comando.Parameters.AddWithValue(nombre, valor); //<-- Se establece el valor del parámetro especificado en el objeto "comando". El método "AddWithValue" del objeto "Parameters" se utiliza para agregar un nuevo parámetro al objeto "comando" y establecer su valor. El primer parámetro es la cadena "nombre", que representa el nombre del parámetro, y el segundo parámetro es el valor que se va a asignar al parámetro.
            
        }



        public void cerrarConexion() //<-- El método "cerrarConexion", el cual no tiene parámetros de entrada y no devuelve nada. El propósito de este método es cerrar la conexión con la base de datos.
        {
            if (lector != null) //<--  Se verifica si el objeto "lector" no es nulo. Si el objeto "lector" no es nulo, entonces se llama al método "Close" del objeto "lector" para cerrar el lector de datos.
                lector.Close();
            conexion.Close(); //<-- Se cierra la conexión con la base de datos utilizando el método "Close" del objeto "conexion". Esto asegura que la conexión con la base de datos se cierre correctamente.
        }


    }