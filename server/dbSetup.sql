CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) COMMENT 'User Name',
  email VARCHAR(255) UNIQUE COMMENT 'User Email',
  picture VARCHAR(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE recipes(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  creator_id VARCHAR(255) NOT NULL,
  title VARCHAR(255) NOT NULL,
  instructions VARCHAR(5000),
  img VARCHAR(1000) NOT NULL,
  category ENUM('breakfast', 'lunch', 'dinner', 'snack', 'dessert') NOT NULL,
  FOREIGN KEY (creator_id) REFERENCES accounts(id) ON DELETE CASCADE
)

CREATE TABLE ingredients(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  recipe_id INT NOT NULL,
  name VARCHAR(255) NOT NULL,
  quantity VARCHAR(255) NOT NULL,
  FOREIGN KEY (recipe_id) REFERENCES recipes(id) ON DELETE CASCADE
);

CREATE TABLE favorites(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  recipe_id INT NOT NULL,
  account_id VARCHAR(255),
  FOREIGN KEY BIGINT(recipe_id) REFERENCES ingredients(recipe_id) ON DELETE CASCADE,
  FOREIGN KEY BIGINT(account_id) REFERENCES accounts(id) ON DELETE CASCADE,
)

SELECT * FROM ingredients;

INSERT INTO 
      ingredients(name, quantity, recipe_id)
      VALUES("corn", 2, 3);
      SELECT
      ingredients.*
      FROM ingredients
      WHERE ingredients.id = LAST_INSERT_ID();

DELETE FROM ingredients WHERE id = 2 LIMIT 1;

      SELECT
      ingredients.*,
      accounts.*
      FROM ingredients
      JOIN accounts ON accounts.id = ingredients.id
      WHERE recipe_id = 8;

      SELECT ingredients.* FROM ingredients WHERE ingredients.id= 3;

DROP TABLE ingredients;

SELECT * FROM recipes;

SELECT * FROM ingredients WHERE id = 3;


UPDATE recipes 
SET 
category = "snack" 
WHERE id = 3;