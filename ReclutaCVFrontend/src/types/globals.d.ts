/**
 * Con esto se hace posible la importación de recursos con extensión PNG
 */
declare module "*.png" {
    const value: any;
    export = value;
}