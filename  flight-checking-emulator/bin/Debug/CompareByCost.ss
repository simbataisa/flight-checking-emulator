; INPUT: (list (list "Arrival Time", "Departure Time", "Next Day Flag"))
(define (CompareByCost info1 info2)
  (if    
     ; both flights null?
     (and
      (null? info1)
      (null? info2)
     )
     ;return 0 as they are equal
     "0"
     ; both flights not null?
     (if
      (and
       (not (null? info1))
       (not (null? info2))
      )
      ; compare the flight cost, i.e travelling time.
      (check-flight-cost info1 info2)
      
      ; 1 null, the other not. 
      (number->string (- (length info1) (length info2)))
     )       
  )
)

(define (check-flight-cost info1 info2)
  ; if the length of both flight lists are the same
  (if (= (length info1) (length info2))
      (let(        
           (t1 (total-flight-time info1 1 0))
           (t2 (total-flight-time info2 1 0)))
        
        ; get the difference in flight times
        (number->string (- t1 t2))
        )
      
      ; else if the length is different
      (number->string (- (length info1) (length info2)))
      )
)

; method to parse the string into time format
(define (get-hour strTime)
  (string->number (substring strTime 0 2))
)

(define (get-mins strTime)
  (string->number (substring strTime 3 5))
)

(define (check-time-diff a b c)
  (let(
       ; assigining the hours and mins
      (hour1 (get-hour a)) 
      (min1 (get-mins a))
      (hour2 (get-hour b)) 
      (min2 (get-mins b)) 
      )
    
    ; if next day flag is on, + 24hrs to the arrival time
    (if(string=? c "1")
		(set! hour1 (+ hour1 24))
		(set! hour1 hour1)
	)
       
    ; convert the hours into mins
    (set! min1 (+ (* hour1 60) min1))
    (set! min2 (+ (* hour2 60) min2))
    
    ; find the differenceeeee!
    (- min1 min2)

  )
)

; just a method to see the time difference in HH:MM format
(define (convert min)
  (define res "Time difference[HH:MM] = ")
   (string-append res (number->string(quotient min 60)) ":" 
                  (number->string(remainder min 60))) 
   
)

; A recursive function to calcuate total flight time
; info1 is the original string listing of ALL the flights
; count is to keep track of the position in the recursive call
; result is a container to store previously calculated results.
(define (total-flight-time info1 count result)
  (let(
       ; get the nth flight to be summed and assign it to n
       (n (get-nth-item count info1))
       )     
    (cond 
      ; termination condition: count = total, return whatever results obtained
      ((= count (length info1)) (sum n result))
      
      ; there's still more to add, keep it going
      (else (total-flight-time info1 (+ count 1) (sum n result)))
    )    
  )
)
  
(define (sum a b)
    ; apply summation to the 2 time variables in list format
    (+ (check-time-diff (get-nth-item 1 a) (get-nth-item 2 a) (get-nth-item 3 a)) b)    
 )


(define (get-nth-item index info1)
  (if (= index 1)
    ; End/destination reached, return the head
    (car info1)
    ; move to next slot, decrement the index and make the list shorter
    (get-nth-item (- index 1) (cdr info1))
  )
)

