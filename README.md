#WebApiStore es una apiRest desarrollado en dotNet Core 6


Una tienda online necesita realizar el movimiento de stock de sus inventarios, WebApiStore en su primera versión básicamente es una api que nos permite crear productos y servicios.
Los productos pueden guardar registro de sus movimientos y actualizar stock de dichos productos.
Los end points habilitados son los siguientes:

# Productos #

|Ruta||Función|
|----------|----------|----------|
|/api/v1/products|GET| Listado de productos|
|/api/v1/products|POST| Registra nuevo producto o servicio|
|/api/v1/products/{id}|PUT|Actualiza producto existente|
|/api/v1/products/{id}|GET|Recupera un producto seleccionado por Id|
|/api/v1/products/{id}|DELETE|Elimina un producto de la lista de productos|

# Transacciones #
|Ruta||Función|
|----------|----------|----------|
|/api/v1/transactions|GET| Listado de transacciones de inventario|
|/api/v1/transactions|POST| Registra nueva transaccion de inventario (INGRESO, EGRESO)|
|/api/v1/transactions/{id}|GET|Recupera una transaccion seleccionado por Id|
|/api/v1/transactions/{id}|DELETE|Elimina una transaccion seleccionada|
