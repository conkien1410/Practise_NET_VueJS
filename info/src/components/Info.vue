<script lang="ts">
// import { defineComponent } from 'vue'
// import  { PropType } from 'vue'
import { PersonDTO } from '../models/Person'
import { mapActions, mapState, mapStores } from 'pinia'
import { usePersonStore } from '../stores/PersonStore'



// export default defineComponent({
//     props: {
//         person: {
//             type: Person,
//             required: true
//         }
//     },
//     mounted() {
//         this.person = {
//             name: "Test",
//             id: "123",
//         }
//     }
// })

import { defineComponent, ref } from 'vue'
import type { PropType } from 'vue'
import { PersonService } from '../services/PersonService'
import { useObservable, useSubscription } from '@vueuse/rxjs'
import { useTimeoutFn } from '@vueuse/shared'

// interface PersonDTO {
//   name?: string
//   dob?: Date
//   id?: string
// }

export default defineComponent({
  computed: {
    ...mapStores(usePersonStore),
    ...mapState(usePersonStore, ['title']),
    person() {
      return this.personStore.person
    }
  },
  methods: {
    ...mapActions(usePersonStore, ['getPerson'])
  },
  
  data() {
    return {
        person2: {
            name: "asdf"
        },
    }
    // person: {
    //   // provide more specific type to `Object`
    //   type: Object as PropType<Person>,
    //   required: true
    // },
   
  },
  created() {
    console.log("created")
    // this.person  = ref<PersonDTO>({
    //     name: "Anh123",
    // })
    //this.getPerson()

    

    // TS Error: argument of type 'string' is not
    // assignable to parameter of type 'number'
    // this.callback?.('123')
  },
  mounted() {
    console.log("mounted")
    useTimeoutFn(() => {
      this.getPerson()

    }, 5000)
  

    // PersonService.getAllPeople().subscribe(res => 
    // {
    //   // console.log("123 456")
    //   console.log(res)
    //   this.person = res

    // });

    // fetch('https://localhost:7000/api/person')
    // .then((response) => {
    //   console.log("123")
    //   console.log(response)
    // })

 
  }
})

</script>
 
<template>
    <div>
        <div>{{this.title}}</div>
        <div>{{this.person.name}}</div>
        
    </div>
</template>