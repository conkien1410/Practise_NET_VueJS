import { defineComponent } from 'vue'
import type { PropType } from 'vue'

interface Person {
  name: string
  dob: Date
  id: string
}

export default defineComponent({
  props: {
    person: {
      // provide more specific type to `Object`
      type: Object as PropType<Person>,
      required: true
    },
   
  },
  mounted() {
    this.book.title // string
    this.book.year // number

    this.person = {
      name: "Anh"
    }

    // TS Error: argument of type 'string' is not
    // assignable to parameter of type 'number'
    // this.callback?.('123')
  }
})
