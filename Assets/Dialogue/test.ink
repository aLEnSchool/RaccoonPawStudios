INCLUDE event_variables.ink

{itemPickedUp == true: ->Triggered | ->notTriggered}
=== notTriggered ===
This is a test
Here's another line
I want rocks : {itemPickedUp}
->DONE

=== Triggered ===
Now interacted with thing
Yup
It worky
-> DONE
    
== function changeItemPickedUp(value) ==
    ~itemPickedUp = value
