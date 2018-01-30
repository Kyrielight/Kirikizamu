"""
get_json.py attempts to take a directive to a JSON object and return a
JSON object from it. It first tries to load the directive as a local file,
and then attempts to load it as a URL. If both fail, it will raise an error.

!!  get_json does NOT make sure the json is malformed (for example, if the json
object is actually a completely unrelated json file). It only loads JSON
and returns a JSON object for the program to use.

This file uses Google's Python style guide:
https://google.github.io/styleguide/pyguide.html
"""

import json
import os

from urllib.request import urlopen
from urllib.parse import urlparse
from urllib.error import URLError, HTTPError


HTTP_ERR_STRING =   ('An invalid file or URL was provided for the %s. \n'
					'Alternatively, your computer may not be '
					'connected to the internet.\n')
VAL_ERR_STRING = 	('An invalid file or URL was provided for the %s.\n')
NO_SCHEME_STRING = 	('An invalid file or URL was provided for the %s. '
					'If a URL, please make sure the URL contains a scheme! '
					'("http://" or "https://")\n')


def get_JSON(jsonobject):
	"""
	get_JSON() attempts to load a reference to a JSON object and then return
	it as a json object. It will try to load as a local file, and then a URL,
	in that order.

	Args:
		jsonobject: Reference to a json file or URL.

	Returns: Python-parseable JSON object from the passed in reference.

	Raises:
		ValueError: If jsonobject fails to load as a file or URL. 
		HTTPError: If a URL returned an HTTP status error code
	"""
	jsonfile = None # Var to keep track of the string json to be loaded

	try:
		# Attempt to load jsonobject as a local file
		with open(os.path.abspath(jsonobject)) as file:
				jsonfile = file.read()

	# FileNotFound error occurs if bad file (or URL) is passed in
	except FileNotFoundError:
		try:
			jsonfile = urlopen(jsonobject, timeout=5).read().decode()
		# THIS  MUST COME BEFORE URLERROR
		except HTTPError:
			raise HTTPError(HTTP_ERR_STRING)
		# Raises URLError if a malformed or bad URL is passed in
		except URLError:
			raise ValueError(VAL_ERR_STRING)
		except ValueError as e:
			# No scheme has a separate error message
			if not urlparse(jsonobject).scheme:
				raise ValueError(NO_SCHEME_STRING)
			else:
				raise ValueError(VAL_ERR_STRING)

	# File/URL successfully obtained, attempt to load it as a JSON object
	try:
		return json.loads(jsonfile)
	# File/URL was NOT a json-formatted file, throw error and exit.
	except ValueError:
		raise ValueError(VAL_ERR_STRING)


# Define get_JSON to be entry point if this file is used standalone
if __name__ == "__main__":
	try:
		get_JSON('YOUR DIRECTIVE HERE')
	except Exception as e:
		print(str(e) % 'cart')
		