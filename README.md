Code expects you to have a local database named AgileWorks:
```
create database agileWorks;
```
Database also has the follwing table where the data is being stored:
```
CREATE TABLE tickets (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    comment VARCHAR(250) NOT NULL,
    createDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    deadLine DATETIME NOT NULL,
    is_completed BIT NULL DEFAULT 0
);
```
Some example data:
```
INSERT INTO tickets (comment, createDate, deadLine)
VALUES
('Ticket desc here',      '2024-02-21 09:00:00', '2024-05-29 15:50:51'),
('Lorem Ipsum something', '2024-02-29 09:00:00', '2024-02-29 09:59:59'),
('Urgent issue',          '2024-03-01 17:55:00', '2024-03-04 08:00:00'),
('Deadline has passed',   '2023-12-01 11:00:00', '2024-01-01 16:00:27');
```
