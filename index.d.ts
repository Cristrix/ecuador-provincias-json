export interface Parroquias {
    [key: string]: string;
}

export interface Canton {
    canton: string;
    parroquias: Parroquias;
}

export interface Cantones {
    [key: string]: Canton;
}

export interface Provincia {
    provincia: string;
    cantones: Cantones;
}

export interface EcuadorLocations {
    [key: string]: Provincia;
}

declare const data: EcuadorLocations;
export default data;
