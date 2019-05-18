
export abstract class View<T>{

    protected _elemento: JQuery;
    private _escapar: boolean;

    constructor(seletor: string, escapar: boolean = false){
        this._elemento = $(seletor);
        this._escapar = escapar;
    }

    update(model: T): void {
        const t1 = performance.now();

        let template = this.template(model);
        if(this._escapar)
            template = template.replace(/<script>[\s\S]*?<\/script>/, '');
        this._elemento.html(this.template(model));

        const t2 = performance.now();
        console.log(`O tempor de execução de update é de ${t2 - t1}ms`);
    }

    abstract template(model: T): string;
}