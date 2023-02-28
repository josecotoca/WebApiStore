#WebApiStore es una apiRest desarrollado en dotNet Core 6
Ejemplo de solución aplicando arquitecturas limpias


Una tienda online necesita realizar el movimiento de stock de sus inventarios, WebApiStore en su primera versión básicamente es una api que nos permite crear productos y servicios.
Los productos pueden guardar registro de sus movimientos y actualizar stock de dichos productos.
Los end points habilitados son los siguientes:

# Productos #

|Ruta||Función|
|----------|----------|----------|
|/api/v2/products/GetByName/{productName?}|GET| Listado de productos con filtro de busqueda por nombre|
|/api/v2/products/GetById/{productId}|GET|Recupera un producto seleccionado por Id|
|/api/v2/products|POST| Registra nuevo producto o servicio|
|/api/v2/products|PUT|Actualiza producto existente|
|/api/v2/products/{productId}|DELETE|Elimina un producto de la lista de productos|
