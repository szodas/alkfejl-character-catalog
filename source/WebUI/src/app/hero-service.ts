import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Hero } from './domain/hero';
import { Observable, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { MessageService } from './message-service';
import { environment } from './../environments/environment';
import { UpdateResponse } from './domain/updateResponse';

@Injectable({
  providedIn: 'root',
})
export class HeroService {
  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) {}

  apiUrl = environment.apiUrl;

  getHero(id: string): Observable<Hero> {
    const url = `${this.apiUrl}/character/${id}`;
    return this.http.get<Hero>(url).pipe(
      tap(character =>
        this.messageService.add(`CharacterService: fetched character with id=${character.id}`)
      ),
      catchError(this.handleError)
    );
  }

  getHeroes(): Observable<Hero[]> {
    const url = `${this.apiUrl}/character`;
    return this.http.get<Hero[]>(url).pipe(
      tap(characters =>
        this.messageService.add(`CharacterService: fetched ${characters.length} characters`)
      ),
      catchError(this.handleError)
    );
  }

  createHero(hero: Hero): Observable<Hero> {
    const url = `${this.apiUrl}/character`;
    return this.http.post<Hero>(url, hero).pipe(
      tap(character =>
        this.messageService.add(`CharacterService: created character with name=${character.name}`)
      ),
      catchError(this.handleError)
    );
  }

  updateHero(hero: Hero): Observable<UpdateResponse> {
    const url = `${this.apiUrl}/character/${hero.id}`;
    return this.http.put<UpdateResponse>(url, hero).pipe(
      tap(res => {
        if (res.updated) {
          this.messageService.add(`CharacterService: updated character with id=${hero.id}`);
        } else {
          this.messageService.add(`CharacterService: character with id=${hero.id} not updated`);
        }
        return res;
      }),
      catchError(this.handleError)
    );
  }

  deleteHero(id: string): Observable<void> {
    const url = `${this.apiUrl}/character/${id}`;
    return this.http.delete<{ id: string; deleted: boolean }>(url).pipe(
      map(res => {
        if (res.deleted) {
          this.messageService.add(`CharacterService: deleted character with id=${id}`);
        } else {
          this.messageService.add(`CharacterService: character with id=${id} not found`);
        }
        return;
      }),
      catchError(this.handleError)
    );
  }

  private handleError(err: HttpErrorResponse): Observable<never> {
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(() => errorMessage);
  }
}