// This is Where all "end" transitions should be placed
// (without all the other code, of course)

// CTRL+F and find codeword "BOAT" for when you should
// transition to the nighttime city skyline.




title: goodEnd
---
// You got him to pay the bill
//You rejected Jeremy's offer to go home but agreed to set up another date
## BOAT
Narrator: You return home on your own with your stomach fuller and your wallet no lighter. Fully refuelled and reinvigorated, you breeze through the rest of your thesis proposal.
Narrator: You got a message from Jeremy the next day, asking about a future date. You agree and set up another date, this time at a pho restaurant he recommended.
Narrator: Maybe wanted to get another meal out of him, maybe you just wanted to spend more time with him.
Narrator: You're not entirely sure, but either way, you enjoyed your time.
//THE END
//Back to title screen or something
===




title: splitEnd
---
//You had to split the bill with Jeremy
<<set $expression to "Neutral">>
Jeremy: Should we split it? That seems fair to me. //neutral
Narrator: Trapped by social convention, you reluctantly agree to split the bill.
## BOAT
Narrator: You return home on your own with your stomach fuller and your wallet somewhat lighter. Now fully refuelled and reinvigorated, you breeze through the rest of your thesis proposal.
Narrator: You got a message from Jeremy the next day, asking about a future date. You waffle back and forth. You figure you can probably get him to pay the whole bill this time, but he was a bit of a weirdo.
Narrator: You eventually agree and set up another date, this time at a pho restaurant he recommended.
//THE END
//Back to title screen or something
===




title: badEnd
---
//Jeremy ditched you with the bill, forcing you to pay it
<<set $expression to "Positive">>
Jeremy: Will excuse me for a moment? I have to use the restroom. //positive EXPRESSION ONLY
Narrator: You wait for what seems like an eternity. Eventually you go to check the bathrooms, only to realize that Jeremy ditched you with the bill.
Narrator: Seems like he didn't enjoy his time with you. With no other choice, you're forced to pay the bill.
Narrator: You feel nauseous as you see the total on the bill and hand the check to the waiter with trembling hands. So much for saving money.
## BOAT
Narrator: You return home on your own with your stomach fuller and your wallet significantly lighter.
Narrator: Too exhausted to finish your thesis, decide to put it off until tomorrow, you've got plenty of time after all. You never got another message from Jeremy.
//THE END
//Back to title screen or something
===




title: dtfSadEnd
---
## BOAT
// no script or code here yet
===




title: dtfHappyEnd
---
## BOAT
// no script or code here yet
===




title: dtfMovieEnd
---
## BOAT
// no script or code here yet
===