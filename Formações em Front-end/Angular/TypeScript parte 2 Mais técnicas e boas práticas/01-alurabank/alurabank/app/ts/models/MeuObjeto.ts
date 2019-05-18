import { Igualavel } from './igualavel';
import { Imprimivel } from './index';


export interface MeuObjeto<T> extends Imprimivel, Igualavel<T>{

}