import { Observable, BehaviorSubject } from "rxjs";

export class Store<T> {
    public state$: Observable<T>;
    private internalState$: BehaviorSubject<T>;

    public constructor(initialState: T) {
        this.internalState$ = new BehaviorSubject(initialState);
        this.state$ = this.internalState$.asObservable();
    }

    get state(): T {
        return this.internalState$.getValue();
    }

    public setState(nextState: T): void {
        this.internalState$.next(nextState);
    }
}