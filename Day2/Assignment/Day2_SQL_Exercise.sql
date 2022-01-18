-- day2 18/01/2022 exercises
use pubs

select * from INFORMATION_SCHEMA.tables;

-- 1) select all the author's details
select * from authors

-- 2) print all the author's full name
select concat(au_fname,' ',au_lname) 'Author Full Name'
from authors

-- 3) Print the average price , total price of all the titles
select avg(price) 'Average Price', sum(price) 'Total Price'
from titles

-- 4) Print the average price of a titles published by '0736'
select avg(price) 'Average Price'
from titles
where pub_id = '0736'

-- 5) print the titles which have advance min of 3200 and maximum of 5000
select title
from titles
where advance > 3200 and advance < 5000

-- 6) Print the titles which are of type 'psychology' or 'mod_cook'
select title
from titles
where type = 'psychology' or type = 'mod_cook'

-- 7) print all titles published before '1991-06-09 00:00:00.000'
select title
from titles
where pubdate < '1991-06-09 00:00:00.000'

-- 8) Select all the authors from 'CA'
select *
from authors
where state = 'CA'

-- 9) Print the average price of titles in every type
select type, avg(price) 'Average Price'
from titles
group by type

-- 10) print the sum of price of all the books pulished by every publisher
select pub_id, sum(price) 'Sum of Price'
from titles
group by pub_id

-- 11) Print the first published title in every type
select a.type, a.title, a.pubdate
from titles as a join (select type, min(pubdate) pubdate
					   from titles
					   group by type) as b
on a.type = b.type
and a.pubdate = b.pubdate

-- 12) calculate the total royalty for every publisher
select pub_id, sum(royalty) 'Total Royalty'
from titles
group by pub_id

-- 13) print the titles sorted by published date
select title, pubdate
from titles
order by pubdate

-- 14) print the titles sorted by publisher then by price
select title, pub_id, price
from titles
order by pub_id, price

-- 15) Print the books published by authors from 'CA'
select distinct title, state
from titles t join titleauthor ta on t.title_id = ta.title_id
			  join authors a on ta.au_id = a.au_id
where state = 'CA'

-- 16) Print the author name of books whcih have royalty more than the average royalty of all the titletes
select concat(au_fname,' ',au_lname) 'Author Name'
from titles t join titleauthor ta on t.title_id = ta.title_id
			  join authors a on ta.au_id = a.au_id
where royalty > (select avg(royalty)
				 from titles)

-- 17) Print all the city and the number of pulishers in it, only if the city has more than one publisher
select city, count(pub_id) 'Num of Publisher'
from publishers
group by city
having count(pub_id) > 1

-- 18) Print the total number of orders for every title
select title, count(ord_num) 'Total Orders'
from titles t left outer join sales s on t.title_id = s.title_id
group by title

-- 19) Print the total number of titles in every order
select ord_num, count(title_id) 'Total Num of Titles'
from sales
group by ord_num

-- 20) Print the order date and the title name
select ord_date, title
from sales s join titles t on s.title_id = t.title_id

-- 21) Print all the title names and publisher names
select title, pub_name
from titles t join publishers p on t.pub_id = p.pub_id

-- 22) print all the publisher names(even if they have not published) and the title names that they have published
select pub_name, title
from publishers p left outer join titles t on p.pub_id = t.pub_id

-- 23) print the title id and the numebr of authors contributing to it
select title_id, count(au_id) 'Num of Authors'
from titleauthor
group by title_id

-- 24) Print the title name and the author name
select title, concat(au_fname,' ',au_lname) 'Author Name'
from titles t join titleauthor ta on t.title_id = ta.title_id
			  join authors a on ta.au_id = a.au_id

-- 25) print the title name, author name and the publisher name
select title, concat(au_fname,' ',au_lname) 'Author Name', pub_name
from titles t join titleauthor ta on t.title_id = ta.title_id
			  join authors a on ta.au_id = a.au_id
			  join publishers p on t.pub_id = p.pub_id

-- 26) print the title name author name, publisher name, orderid, order date, quantity ordered and the total price
select title, concat(au_fname,' ',au_lname) 'Author Name', pub_name, ord_num, ord_date, price*qty 'Total Price'
from titles t join titleauthor ta on t.title_id = ta.title_id
			  join authors a on ta.au_id = a.au_id
			  join publishers p on t.pub_id = p.pub_id
			  left outer join sales s on t.title_id = s.title_id

-- 27) given a title name print the stores in which it ws sold
select stor_name
from titles t left outer join sales s on t.title_id = s.title_id
						 join stores st on s.stor_id = st.stor_id
where title = ''

-- 28) Select the stor_id who have taken more than 2 orders
select stor_id
from sales
group by stor_id
having count(stor_id) > 2


-- 29) Select all the titles and print the first order date (titles that have not be ordered should also be present)
select title, min(ord_date) 'First Order Date'
from titles t left outer join sales s on t.title_id = s.title_id
group by title

-- 30) select all the data from teh orderes and the authors table
select *
from sales, authors
