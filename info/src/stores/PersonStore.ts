import { defineStore } from 'pinia'
import { PersonDTO } from '../models/Person'
import { PersonService } from '../services/PersonService'
import { useSubscription } from '@vueuse/rxjs'


export const usePersonStore = defineStore('person', {
    state: ()  => {
        return {
            title: "Test Person Title",
            person: {
                name: "Test"
            } as PersonDTO
        }
    },
    actions: {
        getPerson() {
            useSubscription(
                PersonService.getAllPeople()
                  .subscribe((res) => {
                    this.person = res
                })
            )
        }
    }
})