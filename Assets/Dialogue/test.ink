INCLUDE event_variables.ink

{ objectPickedUp == true: ->notTriggered | ->Triggered}

=== notTriggered ===
This is a test
Here's another line
I want rocks
->DONE

=== Triggered ===
Now interacted with thing
Yup
It worky
-> DONE

=== function objectPickedUp(pickUp) ===
~itemPickedUp = pickUp
~return itemPickedUp