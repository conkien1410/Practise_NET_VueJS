import { from } from "@vueuse/rxjs"
import { map, Observable } from "rxjs"
import axios from "axios"
import { PersonDTO } from "../models/Person"


const PersonService = {
    getAllPeople: (): Observable<PersonDTO> => {
        return from(axios.get('https://localhost:7000/api/person', { headers: { 'username': 'Test' }}))
        .pipe(
            map((value, index) => {
                
                return value.data[0] as PersonDTO
            })
        );
        // return from(fetch('https://localhost:7000/api/person'))
        // .pipe(
        //     map((value, index) => {
        //         console.log(value)
        //     })

        // )
    }
}
export { PersonService }