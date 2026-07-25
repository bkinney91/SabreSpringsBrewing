import { Container } from "inversify";
import { ServiceTypes } from "../symbols";

export class ContainerService {
    private configured: boolean = false;
    private container: Container;
    private static instanceInternal: ContainerService;
    private constructor() {
        this.container = new Container();
    }

    static get instance(): ContainerService {
        if (!ContainerService.instanceInternal) {
            ContainerService.instanceInternal = new ContainerService();
        }
        return ContainerService.instanceInternal;
    }

    static set instance(value: ContainerService) {
        throw Error("Cannot set instance value");
    }

    public getContainer(): Container {
        if (this.configured) {
            return this.container;
        }
        // return main container
        this.container.bind<Container>(ServiceTypes.Container).toConstantValue(this.container);

        this.configured = true;
        return this.container;
    }
}
