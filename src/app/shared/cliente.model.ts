export interface Cliente{
    dni: string;
    pass:string;
    nombre?:string;
    direccion?:string;
    telefono?:string;
    facturas?: Factura[];
}

export interface Factura{
    id: number;
    fecha: Date;
    esPagada: Boolean;
    esAnulada: Boolean;
    lineas: Linea [];
    dameTotal: number;
}

export interface Linea {
    numLinea: number;
    precio: number;
}

export interface Coche {
    numLicencia: number;
    categoria:   number;
    estado:      number;
}

export interface Reserva {
    id:     number;
    inicio: Date;
    final:  Date;
    coches: Coches;
}

export interface Coches {
    numLicencia: number;
    categoria:   number;
    estado:      number;
}
