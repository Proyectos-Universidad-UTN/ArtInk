namespace ArtInk.Application.Configuration.Pagination;

public class PaginationParameters
{
    // Parametrizamos una constante en 50 para delimitar un maximo hipotetico
    const int MAXPAGESIZE = 50;

    // Creamos una variable para el manejo del numero de pagina
    public int PageNumber { get; set; } = 1;

    // Definimos una variable privada para el tamaño maximo de pagina real.
    private int _pageSize = 10;

    // Creamos la variable publica que nos devuelve el tamaño
    public int PageSize
    {
        // Devolvemos el tamaño en el método get
        get => _pageSize;

        // Seteamos el tamaño basado en si el maximo hipotetico es alcanzado o no
        set => _pageSize = value > MAXPAGESIZE ? MAXPAGESIZE : value;
    }

    public bool Paginated { get; set; } = false;
}